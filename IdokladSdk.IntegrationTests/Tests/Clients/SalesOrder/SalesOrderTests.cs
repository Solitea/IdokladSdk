using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOrder
{
    [TestFixture]
    public partial class SalesOrderTests : TestBase
    {
        private const int PartnerId = 323823;
        private const int SalesOrderId = 1002;
        private SalesOrderClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.SalesOrderClient;
        }

        [Test]
        public void Post_SuccessfullyCreated()
        {
            // Arrange
            var model = GetSalesOrderPostModel();

            // Act
            var result = _client.Post(model).AssertResult();

            // Assert
            Assert.Greater(result.Id, 0);
            Assert.AreEqual(model.DateOfIssue.Date, result.DateOfIssue);
            Assert.AreEqual(PartnerId, result.PartnerId);
            Assert.Greater(result.Items.Count, 0);
            _client.Delete(result.Id).AssertResult();
        }

        [Test]
        public void Delete_SuccessfullyDeleted()
        {
            // Arrange
            var model = GetSalesOrderPostModel();
            var result = _client.Post(model).AssertResult();

            // Act
            var data = _client.Delete(result.Id).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public void Get_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(SalesOrderId).Get().AssertResult();

            // Assert
            Assert.AreEqual(SalesOrderId, data.Id);
            Assert.Greater(data.Attachments.Count, 0);
        }

        [Test]
        public void Get_WithInclude_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(SalesOrderId)
                .Include(s => s.Partner)
                .Get()
                .AssertResult();

            // Assert
            Assert.AreEqual(SalesOrderId, data.Id);
            Assert.IsNotNull(data.Partner);
        }

        [Test]
        public void Update_SuccessfullyUpdated()
        {
            // Arrange
            var model = GetSalesOrderPostModel();
            var result = _client.Post(model).AssertResult();
            var patchModel = new SalesOrderPatchModel
            {
                Id = result.Id,
                Description = "updated description",
                MyAddress = new MyDocumentAddressPatchModel
                {
                    AccountNumber = "555777",
                    Iban = "5453187522"
                }
            };

            // Act
            var data = _client.Update(patchModel).AssertResult();

            // Assert
            Assert.AreEqual(patchModel.Description, data.Description);
            Assert.AreEqual(PartnerId, data.PartnerId);
            Assert.AreEqual(patchModel.MyAddress.AccountNumber, data.MyAddress.AccountNumber);
            Assert.AreEqual(patchModel.MyAddress.Iban, data.MyAddress.Iban);
            _client.Delete(result.Id).AssertResult();
        }

        [Test]
        public void GetIssuedInvoice_SuccessfullyReturnIssuedInvoice()
        {
            // Act
            var issuedInvoice = _client.GetIssuedInvoice(SalesOrderId).AssertResult();

            // Assert
            var salesOrder = _client.Detail(SalesOrderId).Get().AssertResult();
            AssertIssuedInvoice(issuedInvoice, salesOrder);
        }

        [Test]
        public void GetProformaInvoice_SuccessfullyReturnProformaInvoice()
        {
            // Act
            var proformaInvoice = _client.GetProformaInvoice(SalesOrderId).AssertResult();

            // Assert
            var salesOrder = _client.Detail(SalesOrderId).Get().AssertResult();
            AssertProformaInvoice(proformaInvoice, salesOrder);
        }

        [Test]
        public void Get_WithSelect_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(SalesOrderId)
                .Get(s => new
                {
                    s.Id,
                    s.DocumentNumber
                })
                .AssertResult();

            // Assert
            Assert.AreEqual(SalesOrderId, data.Id);
            Assert.AreNotEqual(default(string), data.DocumentNumber);
            Assert.AreNotEqual(string.Empty, data.DocumentNumber);
        }

        [Test]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _client.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public void GetList_WithPage_SuccessfullyReturned()
        {
            // Arrange
            var pageSize = 1;

            // Act
            var data = _client.List()
                .Page(1)
                .PageSize(1)
                .Get()
                .AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.AreEqual(data.TotalItems / pageSize, data.TotalPages);
        }

        [Test]
        public void GetList_WithFilter_SuccessfullyReturned()
        {
            // Arrange
            var id = 1002;

            // Act
            var data = _client.List()
                .Filter(f => f.Id.IsEqual(id))
                .Get()
                .AssertResult();

            // Assert
            Assert.AreEqual(1, data.Items.Count());
            Assert.AreEqual(id, data.Items.First().Id);
        }

        [Test]
        public void GetList_WithComplexFilter_SuccessfullyReturned()
        {
            // Act && Assert
            var data = _client.List()
                .Filter(f => f.DocumentNumber.Contains("005") &&
                            (f.State.IsEqual(SalesOrderState.Created) ||
                             f.State.IsEqual(SalesOrderState.Offered) ||
                             f.State.IsEqual(SalesOrderState.Ordered) ||
                             f.State.IsEqual(SalesOrderState.Invoiced)))
                .Get()
                .AssertResult();
        }

        [Test]
        public void GetList_WithSelect_SuccessfullyReturned()
        {
            // Act
            var data = _client.List()
                .Get(s => new
                {
                    s.Id,
                    s.DocumentNumber
                })
                .AssertResult();

            // Assert
            var salesOrder = data.Items.First();
            Assert.AreNotEqual(default(string), salesOrder.DocumentNumber);
            Assert.AreNotEqual(string.Empty, salesOrder.DocumentNumber);
        }

        [Test]
        public void Recount_SuccessfullyRecounted()
        {
            // Arrange
            var item = new SalesOrderItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new SalesOrderRecountPostModel
            {
                CurrencyId = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                PaymentOptionId = 1,
                Items = new List<SalesOrderItemRecountPostModel> { item }
            };

            // Act
            var data = _client.Recount(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First();
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
        public void Copy_SuccessfullyGetPostModel()
        {
            // Arrange
            var model = GetSalesOrderPostModel();
            model.AccountNumber = "555777";
            var salesOrder = _client.Post(model).AssertResult();

            // Act
            var salesOrderCopy = _client.Copy(salesOrder.Id).AssertResult();

            // Assert
            Assert.AreEqual(salesOrder.Description, salesOrderCopy.Description);
            Assert.AreEqual(PartnerId, salesOrderCopy.PartnerId);
            Assert.AreEqual(salesOrder.MyAddress.AccountNumber, salesOrderCopy.AccountNumber);
            _client.Delete(salesOrder.Id).AssertResult();
        }

        private void AssertIssuedInvoice(IssuedInvoicePostModel issuedInvoice, SalesOrderGetModel salesOrder)
        {
            Assert.AreEqual(SalesOrderId, issuedInvoice.SalesOrderId);
            Assert.AreEqual(salesOrder.Description, issuedInvoice.Description);
            Assert.AreEqual(salesOrder.CurrencyId, issuedInvoice.CurrencyId);
            Assert.AreEqual(salesOrder.ExchangeRate, issuedInvoice.ExchangeRate);
            Assert.AreEqual(salesOrder.ExchangeRateAmount, issuedInvoice.ExchangeRateAmount);
            Assert.AreEqual(salesOrder.PartnerId, issuedInvoice.PartnerId);
            Assert.AreEqual(salesOrder.PaymentOptionId, issuedInvoice.PaymentOptionId);
            Assert.AreEqual(salesOrder.OrderNumber, issuedInvoice.OrderNumber);
            Assert.AreEqual(salesOrder.MyAddress.AccountNumber, issuedInvoice.AccountNumber);
            Assert.AreEqual(salesOrder.MyAddress.Iban, issuedInvoice.Iban);
            Assert.AreEqual(salesOrder.MyAddress.Swift, issuedInvoice.Swift);
        }

        private void AssertProformaInvoice(ProformaInvoicePostModel proformaInvoice, SalesOrderGetModel salesOrder)
        {
            Assert.AreEqual(SalesOrderId, proformaInvoice.SalesOrderId);
            Assert.AreEqual(salesOrder.Description, proformaInvoice.Description);
            Assert.AreEqual(salesOrder.CurrencyId, proformaInvoice.CurrencyId);
            Assert.AreEqual(salesOrder.ExchangeRate, proformaInvoice.ExchangeRate);
            Assert.AreEqual(salesOrder.ExchangeRateAmount, proformaInvoice.ExchangeRateAmount);
            Assert.AreEqual(salesOrder.PartnerId, proformaInvoice.PartnerId);
            Assert.AreEqual(salesOrder.PaymentOptionId, proformaInvoice.PaymentOptionId);
            Assert.AreEqual(salesOrder.OrderNumber, proformaInvoice.OrderNumber);
            Assert.AreEqual(salesOrder.MyAddress.AccountNumber, proformaInvoice.AccountNumber);
            Assert.AreEqual(salesOrder.MyAddress.Iban, proformaInvoice.Iban);
            Assert.AreEqual(salesOrder.MyAddress.Swift, proformaInvoice.Swift);
        }

        private SalesOrderPostModel GetSalesOrderPostModel()
        {
            var model = _client.Default().AssertResult();
            model.Description = "Test";
            model.PartnerId = PartnerId;
            model.DateOfIssue = DateTime.UtcNow.AddDays(-1);
            model.Items.First().Name = "Test";
            model.Items.First().UnitPrice = 100;
            return model;
        }
    }
}
