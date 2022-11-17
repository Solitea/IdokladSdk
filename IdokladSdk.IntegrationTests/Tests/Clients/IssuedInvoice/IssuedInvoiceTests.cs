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

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice;

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
        Assert.Greater(data.Id, 0);
        Assert.AreEqual(_issuedInvoicePostModel.DateOfIssue, data.DateOfIssue);
        Assert.AreEqual(PartnerId, data.PartnerId);
        Assert.Greater(data.Items.Count, 0);
        AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId1);
    }

    [Test]
    [Order(2)]
    public async Task GetAsync_SuccessfullyGet()
    {
        // Act
        var data = await _issuedInvoiceClient.Detail(_issuedInvoiceId).GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(_issuedInvoiceId, data.Id);
        AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId1);
    }

    [Test]
    [Order(3)]
    public async Task GetAsync_Expand_SuccessfullyGet()
    {
        // Act
        var data = await _issuedInvoiceClient.Detail(_issuedInvoiceId)
            .Include(s => s.Partner).GetAsync().AssertResult();

        Assert.AreEqual(_issuedInvoiceId, data.Id);
        Assert.IsNotNull(data.Partner);
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
        Assert.AreEqual(model.Description, data.Description);
        Assert.AreEqual(model.MyAddress.AccountNumber, data.MyAddress.AccountNumber);
        Assert.AreEqual(model.MyAddress.Iban, data.MyAddress.Iban);
        AssertDeliveryAddress(data.DeliveryAddress, DeliveryAddressId2);
    }

    [Test]
    [Order(5)]
    public async Task DeleteAsync_SuccessfullyDeleted()
    {
        // Act
        var data = await _issuedInvoiceClient.DeleteAsync(_issuedInvoiceId).AssertResult();

        // Assert
        Assert.IsTrue(data);
    }

    [Test]
    public async Task GetRecurrenceFromInvoiceAsync_SuccessfullyReturned()
    {
        // Act
        var data = await _issuedInvoiceClient.RecurrenceAsync(InvoiceId).AssertResult();

        // Assert
        Assert.IsNotNull(data);
        Assert.IsNotNull(data.InvoiceTemplate);
        Assert.IsNotNull(data.RecurringSetting);
    }

    [Test]
    public async Task GetListAsync_SuccessfullyReturned()
    {
        // Act
        var data = await _issuedInvoiceClient.List().GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
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
        Assert.AreEqual(item.Id, recountedItem.Id);
        Assert.AreEqual(item.Name, recountedItem.Name);
        Assert.AreEqual(item.ItemType, recountedItem.ItemType);
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
        Assert.AreEqual(1, result.ExchangeRateAmount);
        Assert.AreEqual(20, result.ExchangeRate);
        Assert.AreEqual(2, result.CurrencyId);
        Assert.AreEqual(121, recountedItem.Prices.TotalWithVat);
        Assert.AreEqual(2420, recountedItem.Prices.TotalWithVatHc);
    }

    [Test]
    public async Task Copy_SuccessfullyGetPosModelAsync()
    {
        // Arrange
        var invoiceToCopy = await _issuedInvoiceClient.Detail(InvoiceId).GetAsync().AssertResult();

        // Act
        var data = await _issuedInvoiceClient.CopyAsync(InvoiceId).AssertResult();

        // Assert
        Assert.AreEqual(invoiceToCopy.Description, data.Description);
        Assert.AreEqual(invoiceToCopy.PartnerId, data.PartnerId);
        Assert.AreEqual(invoiceToCopy.CurrencyId, data.CurrencyId);
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
        Assert.Greater(data.Id, 0);
        Assert.Greater(data.Items.Count, 0);
        Assert.AreEqual(data.Items.First().VatRate, 19);

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
        Assert.NotNull(item);
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
        Assert.NotNull(data);
        Assert.NotNull(data.City);
        Assert.AreEqual(expectedDeliveryAddressId, data.ContactDeliveryAddressId);
        Assert.NotZero(data.CountryId);
        Assert.NotNull(data.Name);
        Assert.NotNull(data.PostalCode);
        Assert.NotNull(data.Street);
    }
}
