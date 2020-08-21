using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOrder
{
    public partial class SalesOrderTests
    {
        private const int SalesOrderIdAsync = 1009;

        [Test]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var model = GetSalesOrderPostModel();

            // Act
            var result = (await _client.PostAsync(model)).AssertResult();

            // Assert
            Assert.Greater(result.Id, 0);
            Assert.AreEqual(model.DateOfIssue.Date, result.DateOfIssue);
            Assert.AreEqual(PartnerId, result.PartnerId);
            Assert.Greater(result.Items.Count, 0);
            _client.Delete(result.Id).AssertResult();
        }

        [Test]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Arrange
            var model = GetSalesOrderPostModel();
            var result = _client.Post(model).AssertResult();

            // Act
            var data = (await _client.DeleteAsync(result.Id)).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _client.Detail(SalesOrderIdAsync).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(SalesOrderIdAsync, data.Id);
            Assert.Greater(data.Attachments.Count, 0);
        }

        [Test]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = (await _client.List().GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var item = new SalesOrderItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
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
            var data = (await _client.RecountAsync(model)).AssertResult();

            // Assert
            var recountedItem = data.Items.First(x => x.ItemType == SalesOrderItemType.ItemTypeNormal);
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
        public async Task GetIssuedInvoiceAsync_SuccessfullyReturnIssuedInvoice()
        {
            // Act
            var issuedInvoice = (await _client.GetIssuedInvoiceAsync(SalesOrderId)).AssertResult();

            // Assert
            var salesOrder = _client.Detail(SalesOrderId).Get().AssertResult();
            AssertIssuedInvoice(issuedInvoice, salesOrder);
        }

        [Test]
        public async Task GetProformaInvoiceAsync_SuccessfullyReturnProformaInvoice()
        {
            // Act
            var proformaInvoice = (await _client.GetProformaInvoiceAsync(SalesOrderId)).AssertResult();

            // Assert
            var salesOrder = _client.Detail(SalesOrderId).Get().AssertResult();
            AssertProformaInvoice(proformaInvoice, salesOrder);
        }

        [Test]
        public async Task CopyAsync_SuccessfullyGetPostModel()
        {
            // Arrange
            var model = GetSalesOrderPostModel();
            model.AccountNumber = "555777";
            var salesOrder = _client.Post(model).AssertResult();

            // Act
            var salesOrderCopy = (await _client.CopyAsync(salesOrder.Id)).AssertResult();

            // Assert
            Assert.AreEqual(salesOrder.Description, salesOrderCopy.Description);
            Assert.AreEqual(PartnerId, salesOrderCopy.PartnerId);
            Assert.AreEqual(salesOrder.MyAddress.AccountNumber, salesOrderCopy.AccountNumber);
            _client.Delete(salesOrder.Id).AssertResult();
        }
    }
}
