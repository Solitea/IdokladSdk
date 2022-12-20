using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.DeliveryAddress;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceTests.
    /// </summary>
    [TestFixture]
    public class ProformaInvoiceTests : TestBase
    {
        private const int DeliveryAddressId1 = 11;
        private const int DeliveryAddressId2 = 12;
        private const int PartnerId = 323823;
        private const int UnpaidProformaInvoiceId = 922399;
        private const int AccountedProformaInvoiceId = 922400;

        private readonly List<int> _proformaInvoiceToDeleteIds = new List<int>();
        private readonly List<int> _issuedInvoiceToDeleteIds = new List<int>();
        private int _proformaInvoiceId;

        private ProformaInvoiceClient _proformaInvoiceClient;
        private IssuedInvoiceClient _issuedInvoiceClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _proformaInvoiceClient = DokladApi.ProformaInvoiceClient;
            _issuedInvoiceClient = DokladApi.IssuedInvoiceClient;
        }

        [SetUp]
        public void SetUp()
        {
            _proformaInvoiceToDeleteIds.Clear();
            _issuedInvoiceToDeleteIds.Clear();
        }

        [TearDown]
        public async Task TearDown()
        {
            foreach (var id in _issuedInvoiceToDeleteIds)
            {
                await _issuedInvoiceClient.DeleteAsync(id);
            }

            foreach (var id in _proformaInvoiceToDeleteIds)
            {
                await _proformaInvoiceClient.DeleteAsync(id);
            }
        }

        [Test]
        [Order(1)]
        public async Task Post_SuccessfullyCreatedAsync()
        {
            // Arrange
            var proformaInvoicePostModel = await _proformaInvoiceClient.DefaultAsync().AssertResult();
            proformaInvoicePostModel.PartnerId = PartnerId;
            proformaInvoicePostModel.DeliveryAddressId = DeliveryAddressId1;
            proformaInvoicePostModel.Description = "Test: Update_SuccessfullyUpdated";
            proformaInvoicePostModel.DateOfPayment = DateTime.UtcNow.SetKindUtc();
            proformaInvoicePostModel.IsEet = false;
            proformaInvoicePostModel.Items.Clear();
            proformaInvoicePostModel.Items.Add(new ProformaInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                Amount = 1
            });

            // Act
            var data = await _proformaInvoiceClient.PostAsync(proformaInvoicePostModel).AssertResult();
            _proformaInvoiceId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            Assert.AreEqual(proformaInvoicePostModel.DateOfIssue, data.DateOfIssue);
            Assert.AreEqual(PartnerId, data.PartnerId);
            Assert.AreEqual(proformaInvoicePostModel.DateOfPayment.GetValueOrDefault().Date, data.DateOfPayment);
            Assert.Greater(data.Items.Count, 0);
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId1);
        }

        [Test]
        [Order(2)]
        public async Task Get_SuccessfullyGetAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.Detail(_proformaInvoiceId).GetAsync().AssertResult();

            // Assert
            Assert.AreEqual(_proformaInvoiceId, data.Id);
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId1);
        }

        [Test]
        [Order(3)]
        public async Task Get_Expand_SuccessfullyGetAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.Detail(_proformaInvoiceId)
                .Include(s => s.Partner).GetAsync().AssertResult();

            Assert.AreEqual(_proformaInvoiceId, data.Id);
            Assert.IsNotNull(data.Partner);
        }

        [Test]
        [Order(4)]
        public async Task Update_SuccessfullyUpdatedAsync()
        {
            var model = new ProformaInvoicePatchModel
            {
                Id = _proformaInvoiceId,
                DeliveryAddressId = DeliveryAddressId2,
                Description = "Test: Update_SuccessfullyUpdated",
                MyAddress = new MyDocumentAddressPatchModel
                {
                    AccountNumber = "555777",
                    Iban = "5453187522"
                }
            };

            // Act
            var data = await _proformaInvoiceClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.AreEqual(model.Description, data.Description);
            Assert.AreEqual(model.MyAddress.AccountNumber, data.MyAddress.AccountNumber);
            Assert.AreEqual(model.MyAddress.Iban, data.MyAddress.Iban);
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId2);
        }

        [Test]
        [Order(5)]
        public async Task Copy_SuccessfullyGetPostModelAsync()
        {
            // Arrange
            var invoiceToCopy = await _proformaInvoiceClient.Detail(_proformaInvoiceId).GetAsync().AssertResult();

            // Act
            var data = await _proformaInvoiceClient.CopyAsync(_proformaInvoiceId).AssertResult();

            // Assert
            Assert.AreEqual(invoiceToCopy.Description, data.Description);
            Assert.AreEqual(invoiceToCopy.PartnerId, data.PartnerId);
            Assert.AreEqual(invoiceToCopy.CurrencyId, data.CurrencyId);
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId2);
        }

        [Test]
        public async Task GetInvoiceForAccount_AlreadyAccounted_ReturnsCorrectErrorCodeAsync()
        {
            // Act
            var result = await _proformaInvoiceClient.GetInvoiceForAccountAsync(AccountedProformaInvoiceId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(DokladErrorCode.AlreadyAccounted, result.ErrorCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public async Task GetInvoiceForAccount_NotPaid_ReturnsCorrectErrorCodeAsync()
        {
            // Act
            var result = await _proformaInvoiceClient.GetInvoiceForAccountAsync(UnpaidProformaInvoiceId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(DokladErrorCode.NotPaid, result.ErrorCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        [Order(6)]
        public async Task GetInvoiceForAccount_SuccessfullyGetIssuedInvoiceAccountPostModelAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.GetInvoiceForAccountAsync(_proformaInvoiceId).AssertResult();

            // Assert
            var item = data.Items.FirstOrDefault(i => i.ItemType == PostIssuedInvoiceItemType.ItemTypeReduce);
            Assert.NotNull(item);
            Assert.That(data.ProformaInvoices, Is.Not.Null.And.Count.EqualTo(1).And.Contains(_proformaInvoiceId));
            Assert.AreEqual(-100, item.UnitPrice);
        }

        [Test]
        [Order(7)]
        public async Task Account_SuccessfullyAccountedAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.AccountAsync(_proformaInvoiceId).AssertResult();
            _issuedInvoiceToDeleteIds.Add(data.Id);

            // Assert
            var item = data.Items.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeReduce);
            Assert.NotNull(item);
        }

        [Test]
        [Order(8)]
        public async Task Delete_SuccessfullyDeletedAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.DeleteAsync(_proformaInvoiceId).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public async Task GetList_SuccessfullyReturnedAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.List().GetAsync().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public async Task AccountMultipleProformas_SuccessfullyAccountedAsync()
        {
            // Arrange
            var proformaModel = await CreateProformaInvoicePostModelAsync();
            var proformaId1 = (await _proformaInvoiceClient.PostAsync(proformaModel).AssertResult()).Id;
            var proformaId2 = (await _proformaInvoiceClient.PostAsync(proformaModel).AssertResult()).Id;
            _proformaInvoiceToDeleteIds.AddRange(new[] { proformaId1, proformaId2 });
            var putModel = new AccountProformaInvoicesPutModel { ProformaIds = new[] { proformaId1, proformaId2 } };

            // Act
            var result = await _proformaInvoiceClient.AccountMultipleProformaInvoicesAsync(putModel).AssertResult();
            _issuedInvoiceToDeleteIds.Add(result.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetRecurrenceFromInvoice_SuccessfullyReturnedAsync()
        {
            // Act
            var data = await _proformaInvoiceClient.RecurrenceAsync(UnpaidProformaInvoiceId).AssertResult();

            // Assert
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.InvoiceTemplate);
            Assert.IsNotNull(data.RecurringSetting);
        }

        [Test]
        public async Task Recount_SuccessfullyRecountedAsync()
        {
            // Arrange
            var item = new ProformaInvoiceItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new ProformaInvoiceRecountPostModel
            {
                CurrencyId = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                PaymentOptionId = 1,
                Items = new List<ProformaInvoiceItemRecountPostModel> { item }
            };

            // Act
            var data = await _proformaInvoiceClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
            Assert.AreEqual(item.Id, recountedItem.Id);
            Assert.AreEqual(item.Name, recountedItem.Name);
            Assert.AreEqual(242, recountedItem.Prices.TotalWithVat);
            Assert.AreEqual(242, recountedItem.Prices.TotalWithVatHc);
            Assert.AreEqual(42, recountedItem.Prices.TotalVat);
            Assert.AreEqual(42, recountedItem.Prices.TotalVatHc);
            Assert.AreEqual(200, recountedItem.Prices.TotalWithoutVat);
            Assert.AreEqual(200, recountedItem.Prices.TotalWithoutVatHc);
        }

        [Test]
        public async Task Recount_ForeignCurrency_SuccessfullyRecountedAsync()
        {
            // Arrange
            var item = new ProformaInvoiceItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 1,
                Name = "Test",
                Id = 1,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new ProformaInvoiceRecountPostModel
            {
                CurrencyId = 2,
                ExchangeRate = 20,
                ExchangeRateAmount = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                PaymentOptionId = 1,
                Items = new List<ProformaInvoiceItemRecountPostModel> { item }
            };

            // Act
            var result = await _proformaInvoiceClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
            Assert.AreEqual(1, result.ExchangeRateAmount);
            Assert.AreEqual(20, result.ExchangeRate);
            Assert.AreEqual(2, result.CurrencyId);
            Assert.AreEqual(121, recountedItem.Prices.TotalWithVat);
            Assert.AreEqual(2420, recountedItem.Prices.TotalWithVatHc);
        }

        private void AssertDeliveryAddress(DeliveryDocumentAddressGetModel data, int expectedDeliveryAddressId)
        {
            Assert.NotNull(data);
            Assert.NotNull(data.City);
            Assert.AreEqual(expectedDeliveryAddressId, data.ContactDeliveryAddressId);
            Assert.NotZero(data.CountryId);
            Assert.NotNull(data.Name);
            Assert.NotNull(data.PostalCode);
            Assert.NotNull(data.Street);
        }

        private async Task<ProformaInvoicePostModel> CreateProformaInvoicePostModelAsync()
        {
            var proformaModel = await _proformaInvoiceClient.DefaultAsync().AssertResult();
            proformaModel.PartnerId = PartnerId;
            proformaModel.Description = "Invoice";
            proformaModel.DateOfPayment = DateTime.UtcNow.SetKindUtc();
            proformaModel.Items.Clear();
            proformaModel.Items.Add(new ProformaInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                Amount = 1
            });

            return proformaModel;
        }
    }
}