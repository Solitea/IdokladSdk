using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Bank;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly;

[TestFixture]
public class BankTests : TestBase
{
    private const int Id = 1;
    private BankClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _client = DokladApi.BankClient;
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
    }

    [Test]
    public async Task DetailAsync_WithParameters_SuccessfullyGet()
    {
        // Act
        var data = (await _client
            .Detail(Id)
            .Include(x => x.Country)
            .GetAsync<BankTestDetail>())
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
        // Arrange
        var countryId = 2;
        var testDate = new DateTime(2018, 1, 1);

        // Act
        var data = (await _client
            .List()
            .Filter(x => x.CountryId.IsEqual(countryId))
            .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
            .Filter(x => x.IsOutOfDate.IsNotEqual(true))
            .Sort(x => x.Id.Desc())
            .GetAsync<BankTestList>())
            .AssertResult();

        // Assert
        Assert.NotNull(data.Items);
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
        Assert.True(data.Items.All(i => i.CountryId == countryId));
        Assert.True(data.Items.All(i => i.DateLastChange > testDate));
        Assert.True(data.Items.All(i => !i.IsOutOfDate));
        Assert.True(data.Items.First().Id > data.Items.Last().Id);
    }
}
