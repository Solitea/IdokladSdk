using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOffice;

/// <summary>
/// SalesOfficeTests.
/// </summary>
public class SalesOfficeTests : TestBase
{
    private const int SalesOfficeId = 12025;
    private SalesOfficeClient _salesOfficeClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _salesOfficeClient = DokladApi.SalesOfficeClient;
    }

    [Test]
    public async Task ListAsync_SuccessfullyGet()
    {
        // Act
        var data = await _salesOfficeClient.List().GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
    }

    [Test]
    public async Task DetailAsync_SuccessfullyGet()
    {
        // Act
        var data = await _salesOfficeClient.Detail(SalesOfficeId).GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(SalesOfficeId, data.Id);
        Assert.AreEqual("Sales office", data.Name);
        Assert.IsNull(data.Country);
    }

    [Test]
    public async Task DetailAsync_Include_SuccessfullyGet()
    {
        // Act
        var data = await _salesOfficeClient.Detail(SalesOfficeId).Include(i => i.Country).GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(SalesOfficeId, data.Id);
        Assert.AreEqual("Sales office", data.Name);
        Assert.NotNull(data.Country);
    }
}
