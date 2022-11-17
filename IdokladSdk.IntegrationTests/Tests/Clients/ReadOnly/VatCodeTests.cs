using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.VatCode;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly;

[TestFixture]
public class VatCodeTests : TestBase
{
    private const int Id = 1;
    private VatCodeClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _client = DokladApi.VatCodeClient;
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

            // .Include(x => x.Country)
            .GetAsync<VatCodeTestDetail>())
            .AssertResult();

        // Assert
        Assert.NotNull(data);
        Assert.IsNotEmpty(data.Code);
        Assert.IsNotEmpty(data.Name);

        // Assert.NotNull(data.Country);
        // Assert.NotNull(data.Country.Name);
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
        var testDate = new DateTime(2018, 1, 1);
        var data = (await _client
            .List()
            .Filter(x => x.CountryId.IsEqual(countryId))
            .Filter(x => x.DateValidityFrom.IsLowerThanOrEqual(testDate))
            .Filter(x => x.DateValidityTo.IsGreaterThanOrEqual(testDate))
            .Sort(x => x.Id.Desc())
            .GetAsync<VatCodeTestList>())
            .AssertResult();

        // Assert
        Assert.NotNull(data.Items);
        Assert.Greater(data.TotalItems, 0);
        Assert.Greater(data.TotalPages, 0);
        Assert.True(data.Items.All(i => i.CountryId == countryId));
        Assert.True(data.Items.All(i => i.DateValidityFrom <= testDate));
        Assert.True(data.Items.All(i => i.DateValidityTo >= testDate));
    }
}
