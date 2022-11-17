using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashRegister;

public class CashRegisterTests : TestBase
{
    private int _newCashRegisterId = 0;
    private CashRegisterClient _cashRegisterClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _cashRegisterClient = DokladApi.CashRegisterClient;
    }

    [Test]
    [Order(1)]
    public async Task PostAsync_SuccessfullyPosted()
    {
        // Arrange
        var model = CreatePostModel();

        // Act
        var data = (await _cashRegisterClient.PostAsync(model)).AssertResult();
        _newCashRegisterId = data.Id;

        // Assert
        Assert.Greater(data.Id, 0);
        AssertData(model, data);
    }

    [Test]
    [Order(2)]
    public async Task DetailAsync_SuccessfullyGetDetail()
    {
        // Act
        var data = (await _cashRegisterClient.Detail(_newCashRegisterId).Include(c => c.Currency).GetAsync()).AssertResult();

        // Assert
        Assert.AreEqual(_newCashRegisterId, data.Id);
        Assert.IsNotEmpty(data.Name);
        Assert.NotNull(data.Currency);
        Assert.AreEqual(data.CurrencyId, data.Currency.Id);
    }

    [Test]
    [Order(3)]
    public async Task UpdateAsync_SuccessfullyUpdated()
    {
        var model = CreatePatchModel();

        // Act
        var data = (await _cashRegisterClient.UpdateAsync(model)).AssertResult();

        // Assert
        AssertData(model, data);
    }

    [Test]
    [Order(4)]
    public async Task ListAsync_SuccessfullyGetList()
    {
        // Act
        var data = (await _cashRegisterClient.List().GetAsync()).AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        var cashRegister = data.Items.FirstOrDefault(c => c.Id == _newCashRegisterId);
        Assert.NotNull(cashRegister);
        Assert.IsNotEmpty(cashRegister.Name);
    }

    [Test]
    [Order(5)]
    public async Task DeleteAsync_SuccessfullyDeleted()
    {
        // Act
        var data = (await _cashRegisterClient.DeleteAsync(_newCashRegisterId)).AssertResult();

        // Assert
        Assert.True(data);
    }

    private void AssertData(CashRegisterPatchModel patchModel, CashRegisterGetModel getModel)
    {
        Assert.AreEqual(patchModel.CurrencyId, getModel.CurrencyId);
        Assert.AreEqual(patchModel.DateInitialState.Value, getModel.DateInitialState);
        Assert.AreEqual(patchModel.Id, getModel.Id);
        Assert.AreEqual(patchModel.InitialState.Value, getModel.InitialState);
        Assert.AreEqual(patchModel.IsDefault, getModel.IsDefault);
        Assert.AreEqual(patchModel.Name, getModel.Name);
    }

    private void AssertData(CashRegisterPostModel postModel, CashRegisterGetModel getModel)
    {
        Assert.AreEqual(postModel.CurrencyId, getModel.CurrencyId);
        Assert.AreEqual(postModel.DateInitialState, getModel.DateInitialState);
        Assert.AreEqual(postModel.InitialState, getModel.InitialState);
        Assert.AreEqual(postModel.IsDefault, getModel.IsDefault);
        Assert.AreEqual(postModel.Name, getModel.Name);
    }

    private CashRegisterPatchModel CreatePatchModel()
    {
        return new CashRegisterPatchModel()
        {
            CurrencyId = 2,
            DateInitialState = null,
            Id = _newCashRegisterId,
            InitialState = null,
            IsDefault = false,
            Name = "My updated cash register"
        };
    }

    private CashRegisterPostModel CreatePostModel()
    {
        return new CashRegisterPostModel
        {
            CurrencyId = 1,
            DateInitialState = new DateTime(2020, 4, 22).SetKindUtc(),
            InitialState = 10000m,
            IsDefault = false,
            Name = "My new cash register"
        };
    }
}
