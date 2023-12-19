using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.DeliveryAddress;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceTests.
    /// </summary>
    [TestFixture]
    public class IssuedInvoiceTests : TestBase
    {
        private const int DeliveryAddressId1 = 11;
        private const int DeliveryAddressId2 = 12;
        private const int PartnerId = 323823;
        private const int GermanPartnerId = 681606;
        private const int InvoiceId = 913242;
        private const int ProformaInvoiceId = 913250;
        private int _issuedInvoiceId;
        private IssuedInvoicePostModel _issuedInvoicePostModel;
        private IssuedInvoiceClient _issuedInvoiceClient;
        private ProformaInvoiceClient _proformaInvoiceClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _issuedInvoiceClient = DokladApi.IssuedInvoiceClient;
            _proformaInvoiceClient = DokladApi.ProformaInvoiceClient;
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            _issuedInvoicePostModel = await _issuedInvoiceClient.DefaultAsync().AssertResult();
            _issuedInvoicePostModel.PartnerId = PartnerId;
            _issuedInvoicePostModel.DeliveryAddressId = DeliveryAddressId1;
            _issuedInvoicePostModel.Description = "Invoice";
            _issuedInvoicePostModel.Items.Clear();
            _issuedInvoicePostModel.Items.Add(new IssuedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100
            });

            // Act
            var data = await _issuedInvoiceClient.PostAsync(_issuedInvoicePostModel).AssertResult();
            _issuedInvoiceId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.DateOfIssue, Is.EqualTo(_issuedInvoicePostModel.DateOfIssue));
            Assert.That(data.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(data.Items.Count, Is.GreaterThan(0));
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId1);
        }

        [Test]
        [Order(2)]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = await _issuedInvoiceClient.Detail(_issuedInvoiceId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_issuedInvoiceId));
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId1);
        }

        [Test]
        [Order(3)]
        public async Task GetAsync_Expand_SuccessfullyGet()
        {
            // Act
            var data = await _issuedInvoiceClient.Detail(_issuedInvoiceId)
                .Include(s => s.Partner).GetAsync().AssertResult();

            Assert.That(data.Id, Is.EqualTo(_issuedInvoiceId));
            Assert.That(data.Partner, Is.Not.Null);
        }

        [Test]
        [Order(4)]
        public async Task Update_SuccessfullyUpdated()
        {
            var model = new IssuedInvoicePatchModel
            {
                Id = _issuedInvoiceId,
                Description = "DescriptionUpdated",
                DeliveryAddressId = DeliveryAddressId2,
                MyAddress = new MyDocumentAddressPatchModel
                {
                    AccountNumber = "555777",
                    Iban = "5453187522"
                }
            };

            // Act
            var data = await _issuedInvoiceClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(model.Description));
            Assert.That(data.MyAddress.AccountNumber, Is.EqualTo(model.MyAddress.AccountNumber));
            Assert.That(data.MyAddress.Iban, Is.EqualTo(model.MyAddress.Iban));
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId2);
        }

        [Test]
        [Order(5)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _issuedInvoiceClient.DeleteAsync(_issuedInvoiceId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        public async Task GetRecurrenceFromInvoiceAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _issuedInvoiceClient.RecurrenceAsync(InvoiceId).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.InvoiceTemplate, Is.Not.Null);
            Assert.That(data.RecurringSetting, Is.Not.Null);
        }

        [Test]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _issuedInvoiceClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var item = new IssuedInvoiceItemRecountPostModel
            {
                DiscountPercentage = 0,
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
                ItemType = IssuedInvoiceItemType.ItemTypeReduce,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new IssuedInvoiceRecountPostModel
            {
                CurrencyId = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                DiscountPercentage = 0,
                PaymentOptionId = 1,
                Items = new List<IssuedInvoiceItemRecountPostModel> { item }
            };

            // Act
            var data = await _issuedInvoiceClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeReduce);
            Assert.That(recountedItem.Id, Is.EqualTo(item.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(item.Name));
            Assert.That(recountedItem.ItemType, Is.EqualTo(item.ItemType));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(200));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(200));
        }

        [Test]
        public async Task Recount_ForeignCurrency_SuccessfullyRecountedAsync()
        {
            // Arrange
            var item = new IssuedInvoiceItemRecountPostModel
            {
                DiscountPercentage = 0,
                UnitPrice = 100,
                Amount = 1,
                Name = "Test",
                Id = 1,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new IssuedInvoiceRecountPostModel
            {
                CurrencyId = 2,
                ExchangeRate = 20,
                ExchangeRateAmount = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                DiscountPercentage = 0,
                PaymentOptionId = 1,
                Items = new List<IssuedInvoiceItemRecountPostModel> { item }
            };

            // Act
            var result = await _issuedInvoiceClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
            Assert.That(result.ExchangeRateAmount, Is.EqualTo(1));
            Assert.That(result.ExchangeRate, Is.EqualTo(20));
            Assert.That(result.CurrencyId, Is.EqualTo(2));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(121));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(2420));
        }

        [Test]
        public async Task Copy_SuccessfullyGetPosModelAsync()
        {
            // Arrange
            var invoiceToCopy = await _issuedInvoiceClient.Detail(InvoiceId).GetAsync().AssertResult();

            // Act
            var data = await _issuedInvoiceClient.CopyAsync(InvoiceId).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(invoiceToCopy.Description));
            Assert.That(data.PartnerId, Is.EqualTo(invoiceToCopy.PartnerId));
            Assert.That(data.CurrencyId, Is.EqualTo(invoiceToCopy.CurrencyId));
            AssertDeliveryAddress(invoiceToCopy.DeliveryAddress, DeliveryAddressId1);
        }

        [Test]
        public async Task PostWithOssRegimeAsync_SuccessfullyCreated()
        {
            // Arrange
            _issuedInvoicePostModel = await _issuedInvoiceClient.DefaultAsync().AssertResult();
            _issuedInvoicePostModel.PartnerId = GermanPartnerId;
            _issuedInvoicePostModel.Description = "MossTest";
            _issuedInvoicePostModel.HasVatRegimeOss = true;
            _issuedInvoicePostModel.Items.Clear();
            _issuedInvoicePostModel.Items.Add(new IssuedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                VatRateType = VatRateType.Basic
            });

            // Act
            var data = await _issuedInvoiceClient.PostAsync(_issuedInvoicePostModel).AssertResult();

            // Assert
            Assert.That(data.HasVatRegimeOss, Is.True);
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.Items.Count, Is.GreaterThan(0));
            Assert.That(data.Items.First().VatRate, Is.EqualTo(19));

            // Teardown
            await _issuedInvoiceClient.DeleteAsync(data.Id);
        }

        [Test]
        public async Task Accounting_SuccessfullyAccountedAsync()
        {
            // Arrange
            var model = await _proformaInvoiceClient.GetInvoiceForAccountAsync(ProformaInvoiceId).AssertResult();

            // Act
            var data = await _issuedInvoiceClient.PostAsync(model).AssertResult();

            // Assert
            var item = data.Items.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeReduce);
            Assert.That(item, Is.Not.Null);
            Assert.That(data.ProformaInvoices, Is.Not.Null.And.Count.EqualTo(1).And.Contains(ProformaInvoiceId));

            // Teardown
            await _issuedInvoiceClient.DeleteAsync(data.Id);
        }

        [Test]
        public async Task Post_NormalInvoiceWithWrongItemType_ThrowsExceptionAsync()
        {
            // Arrange
            var model = await _issuedInvoiceClient.DefaultAsync().AssertResult();
            model.Items[0].ItemType = PostIssuedInvoiceItemType.ItemTypeReduce;

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await _issuedInvoiceClient.PostAsync(model).AssertResult());

            // Assert
            Assert.That(exception, Has.Message.Contains("normal items"));
        }

        private void AssertDeliveryAddress(DeliveryDocumentAddressGetModel data, int expectedDeliveryAddressId)
        {
            Assert.That(data, Is.Not.Null);
            Assert.That(data.City, Is.Not.Null);
            Assert.That(data.ContactDeliveryAddressId, Is.EqualTo(expectedDeliveryAddressId));
            Assert.That(data.CountryId, Is.Not.Zero);
            Assert.That(data.Name, Is.Not.Null);
            Assert.That(data.PostalCode, Is.Not.Null);
            Assert.That(data.Street, Is.Not.Null);
        }
    }
}
