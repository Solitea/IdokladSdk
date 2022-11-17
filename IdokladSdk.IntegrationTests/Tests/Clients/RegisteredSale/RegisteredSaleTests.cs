using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.RegisteredSale;

public class RegisteredSaleTests : TestBase
{
    private readonly int _salesReceiptId = 224892;
    private readonly string _vatIdentificationNumber = "CZ25568736";
    private RegisteredSaleClient _registeredSaleClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _registeredSaleClient = DokladApi.RegisteredSaleClient;
    }

    [Test]
    public async Task List_SuccessfullyGetAsync()
    {
        // Act
        var data = await _registeredSaleClient.List().GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
    }

    [Test]
    public async Task Detail_SuccessfullyGetAsync()
    {
        // Act
        var data = await _registeredSaleClient.Detail(RegisteredSaleType.SalesReceipt, _salesReceiptId).GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(_salesReceiptId, data.SalesReceiptId);
        Assert.AreEqual(_vatIdentificationNumber, data.VatIdentificationNumber);
    }

    [Test]
    public async Task Default_SuccessfullyGetAsync()
    {
        // Act
        var data = await _registeredSaleClient.DefaultAsync().AssertResult();

        // Assert
        Assert.AreEqual(_vatIdentificationNumber, data.VatIdentificationNumber);
    }

    [Test]
    public async Task Post_SuccessfullyCreatedAsync()
    {
        // Arrange
        var model = await _registeredSaleClient.DefaultAsync().AssertResult();
        model.Bkp = "TEST_BKP";
        model.Fik = "TEST_FIK";
        model.Pkp = "TEST_PKP";
        model.ReceiptNumber = "001";
        model.SalesOfficeDesignation = 2;
        model.Uuid = Guid.NewGuid();

        // Act
        var data = await _registeredSaleClient.PostAsync(RegisteredSaleType.SalesReceipt, _salesReceiptId, model).AssertResult();

        // Assert
        Assert.AreEqual(_vatIdentificationNumber, data.VatIdentificationNumber);
        Assert.AreEqual(model.Uuid, data.Uuid);
        Assert.AreEqual(model.Bkp, data.Bkp);
        Assert.AreEqual(model.Fik, data.Fik);
        Assert.AreEqual(model.Pkp, data.Pkp);
        Assert.AreEqual(model.ReceiptNumber, data.ReceiptNumber);
        Assert.AreEqual(model.SalesOfficeDesignation, data.SalesOfficeDesignation);
    }

    [Test]
    public async Task Post_Validation_ThrowsValidationExceptionAsync()
    {
        // Arrange
        var model = await _registeredSaleClient.DefaultAsync().AssertResult();

        // Act
        var exception = Assert.ThrowsAsync<ValidationException>(async () => await _registeredSaleClient.PostAsync(RegisteredSaleType.SalesReceipt, _salesReceiptId, model));

        // Assert
        Assert.AreEqual("Model is not valid.\nThe Bkp field is required.\nThe Fik field is required.\nThe Pkp field is required.\nThe ReceiptNumber field is required.", exception.Message);
    }
}
