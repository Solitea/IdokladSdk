using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceTests.
    /// </summary>
    [TestFixture]
    public partial class IssuedInvoiceTests : TestBase
    {
        private const int PartnerId = 323823;
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
        public void Post_SuccessfullyCreated()
        {
            // Arrange
            _issuedInvoicePostModel = _issuedInvoiceClient.Default().AssertResult();
            _issuedInvoicePostModel.PartnerId = PartnerId;
            _issuedInvoicePostModel.Description = "Invoice";
            _issuedInvoicePostModel.Items.Clear();
            _issuedInvoicePostModel.Items.Add(new IssuedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100
            });

            // Act
            var data = _issuedInvoiceClient.Post(_issuedInvoicePostModel).AssertResult();
            _issuedInvoiceId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            Assert.AreEqual(_issuedInvoicePostModel.DateOfIssue, data.DateOfIssue);
            Assert.AreEqual(PartnerId, data.PartnerId);
            Assert.Greater(data.Items.Count, 0);
        }

        [Test]
        [Order(2)]
        public void Get_SuccessfullyGet()
        {
            // Act
            var data = _issuedInvoiceClient.Detail(_issuedInvoiceId).Get().AssertResult();

            // Assert
            Assert.AreEqual(_issuedInvoiceId, data.Id);
        }

        [Test]
        [Order(3)]
        public void Get_Expand_SuccessfullyGet()
        {
            // Act
            var data = _issuedInvoiceClient.Detail(_issuedInvoiceId)
                .Include(s => s.Partner).Get().AssertResult();

            Assert.AreEqual(_issuedInvoiceId, data.Id);
            Assert.IsNotNull(data.Partner);
        }

        [Test]
        [Order(4)]
        public void Update_SuccessfullyUpdated()
        {
            var model = new IssuedInvoicePatchModel
            {
                Id = _issuedInvoiceId,
                Description = "DescriptionUpdated"
            };

            // Act
            var data = _issuedInvoiceClient.Update(model).AssertResult();

            // Assert
            Assert.AreEqual(model.Description, data.Description);
        }

        [Test]
        [Order(5)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _issuedInvoiceClient.Delete(_issuedInvoiceId).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _issuedInvoiceClient.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public void Recount_SuccessfullyRecounted()
        {
            // Arrange
            var item = new IssuedInvoiceItemRecountPostModel
            {
                DiscountPercentage = 0,
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
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
            var data = _issuedInvoiceClient.Recount(model).AssertResult();

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
        public void Recount_ForeignCurrency_SuccessfullyRecounted()
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
            var result = _issuedInvoiceClient.Recount(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
            Assert.AreEqual(1, result.ExchangeRateAmount);
            Assert.AreEqual(20, result.ExchangeRate);
            Assert.AreEqual(2, result.CurrencyId);
            Assert.AreEqual(121, recountedItem.Prices.TotalWithVat);
            Assert.AreEqual(2420, recountedItem.Prices.TotalWithVatHc);
        }

        [Test]
        public void Copy_SuccessfullyGetPosModel()
        {
            // Arrange
            var invoiceToCopy = _issuedInvoiceClient.Detail(InvoiceId).Get().AssertResult();

            // Act
            var data = _issuedInvoiceClient.Copy(InvoiceId).AssertResult();

            // Assert
            Assert.AreEqual(invoiceToCopy.Description, data.Description);
            Assert.AreEqual(invoiceToCopy.PartnerId, data.PartnerId);
            Assert.AreEqual(invoiceToCopy.CurrencyId, data.CurrencyId);
        }

        [Test]
        public void Accounting_SuccessfullyAccounted()
        {
            // Arrange
            var model = _proformaInvoiceClient.GetInvoiceForAccount(ProformaInvoiceId).AssertResult();

            // Act
            var data = _issuedInvoiceClient.Post(model).AssertResult();

            // Assert
            var item = data.Items.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeReduce);
            Assert.NotNull(item);
            Assert.That(data.ProformaInvoices, Is.Not.Null.And.Count.EqualTo(1).And.Contains(ProformaInvoiceId));

            // Teardown
            _issuedInvoiceClient.Delete(data.Id);
        }

        [Test]
        public void Post_NormalInvoiceWithWrongItemType_ThrowsException()
        {
            // Arrange
            var model = _issuedInvoiceClient.Default().AssertResult();
            model.Items[0].ItemType = PostIssuedInvoiceItemType.ItemTypeReduce;

            // Act
            TestDelegate action = () => _issuedInvoiceClient.Post(model).AssertResult();

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<ValidationException>().And.Message.Contains("normal items"));
        }
    }
}
