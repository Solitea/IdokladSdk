using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.ConstantSymbol;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly;

[TestFixture]
public class ConstantSymbolTests : TestBase
{
    private const int Id = 7;
    private ConstantSymbolClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _client = DokladApi.ConstantSymbolClient;
    }

    [Test]
    public async Task DetailAsync_SuccessfullyGet()
    {
        // Act
        var data = (await _client
            .Detail(Id)
            .GetAsync())
            .AssertResult();

        // Assert
        Assert.NotNull(data);
        AssertionsHelper.AssertDetail(data);
        Assert.True(data.IsDefault);
    }

    [Test]
    public async Task DetailAsync_WithParameters_SuccessfullyGet()
    {
        // Act
        var data = (await _client
            .Detail(Id)
            .Include(x => x.Country)
            .GetAsync<ConstantSymbolTestDetail>())
            .AssertResult();

        // Assert
        Assert.NotNull(data);
        Assert.NotZero(data.Id);
        Assert.IsNotEmpty(data.Name);
        Assert.NotNull(data.Country);
        Assert.NotNull(data.Country.Name);
    }

    [Test]
    public async Task ListAsync_ReturnsNonEmptyList()
    {
        // Act
        var data = (await _client
            .List()
            .GetAsync())
            .AssertResult();

        // Assert
        Assert.NotNull(data.Items);
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
        var firstItem = data.Items.First();
        AssertionsHelper.AssertDetail(firstItem);
    }

    [Test]
    public async Task ListAsync_WithParameters_ReturnsCorrectResult()
    {
        // Act
        var countryId = 2;
        var testDate = new DateTime(2001, 1, 1);
        var data = (await _client
            .List()
            .Filter(x => x.CountryId.IsEqual(countryId))
            .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
            .Sort(x => x.Id.Desc())
            .GetAsync<ConstantSymbolTestList>())
            .AssertResult();

        // Assert
        Assert.NotNull(data.Items);
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
        Assert.True(data.Items.All(i => i.CountryId == countryId));
        Assert.True(data.Items.All(i => i.DateLastChange > testDate));
    }
}
