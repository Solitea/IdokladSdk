using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.DeliveryAddress;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.IssuedInvoice.Get;
using IdokladSdk.Models.ProformaInvoice.Get;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOrder
{
    [TestFixture]
    public class SalesOrderTests : TestBase
    {
        private const int DeliveryAddressId1 = 11;
        private const int DeliveryAddressId2 = 12;
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
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var model = await GetSalesOrderPostModelAsync();

            // Act
            var result = await _client.PostAsync(model).AssertResult();

            // Assert
            Assert.That(result.Id, Is.GreaterThan(0));
            Assert.That(result.DateOfIssue, Is.EqualTo(model.DateOfIssue.Date));
            Assert.That(result.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(result.Items.Count, Is.GreaterThan(0));
            await _client.DeleteAsync(result.Id).AssertResult();
        }

        [Test]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Arrange
            var model = await GetSalesOrderPostModelAsync();
            var result = await _client.PostAsync(model).AssertResult();

            // Act
            var data = await _client.DeleteAsync(result.Id).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = await _client.Detail(SalesOrderId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(SalesOrderId));
            Assert.That(data.Attachments.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task Get_WithInclude_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client.Detail(SalesOrderId)
                .Include(s => s.Partner)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(SalesOrderId));
            Assert.That(data.Partner, Is.Not.Null);
        }

        [Test]
        public async Task Update_SuccessfullyUpdatedAsync()
        {
            // Arrange
            var model = await GetSalesOrderPostModelAsync();
            var result = await _client.PostAsync(model).AssertResult();
            var patchModel = new SalesOrderPatchModel
            {
                Id = result.Id,
                DeliveryAddressId = DeliveryAddressId2,
                Description = "updated description",
                MyAddress = new MyDocumentAddressPatchModel
                {
                    AccountNumber = "555777",
                    Iban = "5453187522"
                }
            };

            // Act
            var data = await _client.UpdateAsync(patchModel).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(patchModel.Description));
            Assert.That(data.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(data.MyAddress.AccountNumber, Is.EqualTo(patchModel.MyAddress.AccountNumber));
            Assert.That(data.MyAddress.Iban, Is.EqualTo(patchModel.MyAddress.Iban));
            AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId2);
            await _client.DeleteAsync(result.Id).AssertResult();
        }

        [Test]
        public async Task GetIssuedInvoiceAsync_SuccessfullyReturnIssuedInvoice()
        {
            // Act
            var issuedInvoice = await _client.GetIssuedInvoiceAsync(SalesOrderId).AssertResult();

            // Assert
            var salesOrder = await _client.Detail(SalesOrderId).GetAsync().AssertResult();
            AssertInvoiceFromSalesOrderGetModel(issuedInvoice, salesOrder);
        }

        [Test]
        public async Task GetProformaInvoiceAsync_SuccessfullyReturnProformaInvoice()
        {
            // Act
            var proformaInvoice = await _client.GetProformaInvoiceAsync(SalesOrderId).AssertResult();

            // Assert
            var salesOrder = await _client.Detail(SalesOrderId).GetAsync().AssertResult();
            AssertProformaFromSalesOrderGetModel(proformaInvoice, salesOrder);
        }

        [Test]
        public async Task Get_WithSelect_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client.Detail(SalesOrderId)
                .GetAsync(s => new
                {
                    s.Id,
                    s.DocumentNumber
                })
                .AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(SalesOrderId));
            Assert.That(data.DocumentNumber, Is.Not.EqualTo(default(string)));
            Assert.That(data.DocumentNumber, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _client.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetList_WithPage_SuccessfullyReturnedAsync()
        {
            // Arrange
            var pageSize = 1;

            // Act
            var data = await _client.List()
                .Page(1)
                .PageSize(1)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.EqualTo(data.TotalItems / pageSize));
        }

        [Test]
        public async Task GetList_WithFilter_SuccessfullyReturnedAsync()
        {
            // Arrange
            var id = 1002;

            // Act
            var data = await _client.List()
                .Filter(f => f.Id.IsEqual(id))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items.Count(), Is.EqualTo(1));
            Assert.That(data.Items.First().Id, Is.EqualTo(id));
        }

        [Test]
        public async Task GetList_WithComplexFilter_SuccessfullyReturnedAsync()
        {
            // Act && Assert
            var data = await _client.List()
                .Filter(f => f.DocumentNumber.Contains("005") &&
                            (f.State.IsEqual(SalesOrderState.Created) ||
                             f.State.IsEqual(SalesOrderState.Offered) ||
                             f.State.IsEqual(SalesOrderState.Ordered) ||
                             f.State.IsEqual(SalesOrderState.Invoiced)))
                .GetAsync()
                .AssertResult();
        }

        [Test]
        public async Task GetList_WithSelect_SuccessfullyReturnedAsync()
        {
            // Act
            var data = await _client.List()
                .GetAsync(s => new
                {
                    s.Id,
                    s.DocumentNumber
                })
                .AssertResult();

            // Assert
            var salesOrder = data.Items.First();
            Assert.That(salesOrder.DocumentNumber, Is.Not.EqualTo(default(string)));
            Assert.That(salesOrder.DocumentNumber, Is.Not.EqualTo(string.Empty));
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
            var data = await _client.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First(x => x.ItemType == SalesOrderItemType.ItemTypeNormal);
            Assert.That(recountedItem.Id, Is.EqualTo(item.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(item.Name));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(200));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(200));
        }

        [Test]
        public async Task CopyAsync_SuccessfullyGetPostModel()
        {
            // Arrange
            var model = await GetSalesOrderPostModelAsync();
            model.AccountNumber = "555777";
            var salesOrder = await _client.PostAsync(model).AssertResult();

            // Act
            var salesOrderCopy = await _client.CopyAsync(salesOrder.Id).AssertResult();

            // Assert
            Assert.That(salesOrderCopy.Description, Is.EqualTo(salesOrder.Description));
            Assert.That(salesOrderCopy.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(salesOrderCopy.AccountNumber, Is.EqualTo(salesOrder.MyAddress.AccountNumber));
            await _client.DeleteAsync(salesOrder.Id).AssertResult();
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

        private void AssertInvoiceFromSalesOrderGetModel(IssuedInvoiceFromSalesOrderGetModel model, SalesOrderGetModel salesOrder)
        {
            Assert.That(model.SalesOrderId, Is.EqualTo(SalesOrderId));
            Assert.That(model.Description, Is.EqualTo(salesOrder.Description));
            Assert.That(model.CurrencyId, Is.EqualTo(salesOrder.CurrencyId));
            Assert.That(model.ExchangeRate, Is.EqualTo(salesOrder.ExchangeRate));
            Assert.That(model.ExchangeRateAmount, Is.EqualTo(salesOrder.ExchangeRateAmount));
            Assert.That(model.PartnerId, Is.EqualTo(salesOrder.PartnerId));
            Assert.That(model.PaymentOptionId, Is.EqualTo(salesOrder.PaymentOptionId));
            Assert.That(model.OrderNumber, Is.EqualTo(salesOrder.OrderNumber));
            Assert.That(model.AccountNumber, Is.EqualTo(salesOrder.MyAddress.AccountNumber));
            Assert.That(model.Iban, Is.EqualTo(salesOrder.MyAddress.Iban));
            Assert.That(model.Swift, Is.EqualTo(salesOrder.MyAddress.Swift));
        }

        private void AssertProformaFromSalesOrderGetModel(ProformaInvoiceFromSalesOrderGetModel model, SalesOrderGetModel salesOrder)
        {
            Assert.That(model.SalesOrderId, Is.EqualTo(SalesOrderId));
            Assert.That(model.Description, Is.EqualTo(salesOrder.Description));
            Assert.That(model.CurrencyId, Is.EqualTo(salesOrder.CurrencyId));
            Assert.That(model.ExchangeRate, Is.EqualTo(salesOrder.ExchangeRate));
            Assert.That(model.ExchangeRateAmount, Is.EqualTo(salesOrder.ExchangeRateAmount));
            Assert.That(model.PartnerId, Is.EqualTo(salesOrder.PartnerId));
            Assert.That(model.PaymentOptionId, Is.EqualTo(salesOrder.PaymentOptionId));
            Assert.That(model.OrderNumber, Is.EqualTo(salesOrder.OrderNumber));
            Assert.That(model.AccountNumber, Is.EqualTo(salesOrder.MyAddress.AccountNumber));
            Assert.That(model.Iban, Is.EqualTo(salesOrder.MyAddress.Iban));
            Assert.That(model.Swift, Is.EqualTo(salesOrder.MyAddress.Swift));
        }

        private async Task<SalesOrderPostModel> GetSalesOrderPostModelAsync()
        {
            var model = await _client.DefaultAsync().AssertResult();
            model.Description = "Test";
            model.PartnerId = PartnerId;
            model.DeliveryAddressId = DeliveryAddressId1;
            model.DateOfIssue = DateTime.UtcNow.AddDays(-1);
            model.Items.First().Name = "Test";
            model.Items.First().UnitPrice = 100;
            return model;
        }
    }
}
