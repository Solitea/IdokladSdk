using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesPosEquipment;

public class SalesPosEquipmentTests : TestBase
{
    private readonly int _salesPosEquipmentId = 12902;
    private readonly int _pairedSalesPosEquipmentId = 12914;
    private SalesPosEquipmentClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi<PinAuthProvider>();
        _client = DokladApi.SalesPosEquipmentClient;
    }

    [Test]
    public async Task Get_WithSelect_SuccessfullyGetAsync()
    {
        // Act
        var data = await _client.Detail(_salesPosEquipmentId)
            .GetAsync()
            .AssertResult();

        Assert.AreEqual(_salesPosEquipmentId, data.Id);
    }

    [Test]
    public async Task GetList_SuccessfullyReturnedAsync()
    {
        // Act
        var data = await _client.List().GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
    }

    [Test]
    public async Task GetInfo_SuccessfullyReturnedAsync()
    {
        // Act
        var data = await _client.Info().GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(_pairedSalesPosEquipmentId, data.Id);
    }
}
