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
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOrder;

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
        Assert.Greater(result.Id, 0);
        Assert.AreEqual(model.DateOfIssue.Date, result.DateOfIssue);
        Assert.AreEqual(PartnerId, result.PartnerId);
        Assert.Greater(result.Items.Count, 0);
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
        Assert.IsTrue(data);
    }

    [Test]
    public async Task GetAsync_SuccessfullyGet()
    {
        // Act
        var data = await _client.Detail(SalesOrderId).GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(SalesOrderId, data.Id);
        Assert.Greater(data.Attachments.Count, 0);
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
        Assert.AreEqual(SalesOrderId, data.Id);
        Assert.IsNotNull(data.Partner);
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
        Assert.AreEqual(patchModel.Description, data.Description);
        Assert.AreEqual(PartnerId, data.PartnerId);
        Assert.AreEqual(patchModel.MyAddress.AccountNumber, data.MyAddress.AccountNumber);
        Assert.AreEqual(patchModel.MyAddress.Iban, data.MyAddress.Iban);
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
        AssertIssuedInvoice(issuedInvoice, salesOrder);
    }

    [Test]
    public async Task GetProformaInvoiceAsync_SuccessfullyReturnProformaInvoice()
    {
        // Act
        var proformaInvoice = await _client.GetProformaInvoiceAsync(SalesOrderId).AssertResult();

        // Assert
        var salesOrder = await _client.Detail(SalesOrderId).GetAsync().AssertResult();
        AssertProformaInvoice(proformaInvoice, salesOrder);
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
        Assert.AreEqual(SalesOrderId, data.Id);
        Assert.AreNotEqual(default(string), data.DocumentNumber);
        Assert.AreNotEqual(string.Empty, data.DocumentNumber);
    }

    [Test]
    public async Task GetListAsync_SuccessfullyReturned()
    {
        // Act
        var data = await _client.List().GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
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
        Assert.Greater(data.TotalItems, 0);
        Assert.AreEqual(data.TotalItems / pageSize, data.TotalPages);
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
        Assert.AreEqual(1, data.Items.Count());
        Assert.AreEqual(id, data.Items.First().Id);
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
        Assert.AreNotEqual(default(string), salesOrder.DocumentNumber);
        Assert.AreNotEqual(string.Empty, salesOrder.DocumentNumber);
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
    public async Task CopyAsync_SuccessfullyGetPostModel()
    {
        // Arrange
        var model = await GetSalesOrderPostModelAsync();
        model.AccountNumber = "555777";
        var salesOrder = await _client.PostAsync(model).AssertResult();

        // Act
        var salesOrderCopy = await _client.CopyAsync(salesOrder.Id).AssertResult();

        // Assert
        Assert.AreEqual(salesOrder.Description, salesOrderCopy.Description);
        Assert.AreEqual(PartnerId, salesOrderCopy.PartnerId);
        Assert.AreEqual(salesOrder.MyAddress.AccountNumber, salesOrderCopy.AccountNumber);
        await _client.DeleteAsync(salesOrder.Id).AssertResult();
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
