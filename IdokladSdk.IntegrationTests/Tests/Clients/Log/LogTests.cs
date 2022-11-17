using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Log;

/// <summary>
/// LogTests.
/// </summary>
[TestFixture]
public class LogTests : TestBase
{
    private LogClient _logClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _logClient = DokladApi.LogClient;
    }

    [Test]
    public async Task GetListAsync_SuccessfullyReturned()
    {
        // Act
        var data = await _logClient.List().GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
    }

    [Test]
    public async Task GetSpecificListAsync_SuccessfullyReturned()
    {
        // Act
        var data = await _logClient.List(913242, LogEntityType.IssuedInvoice).GetAsync().AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.Items.Count(), 0);
    }
}
