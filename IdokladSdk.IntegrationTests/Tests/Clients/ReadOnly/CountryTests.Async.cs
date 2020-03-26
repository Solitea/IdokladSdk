using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Country;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class CountryTests : TestBase
    {
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
                .Include(x => x.Currency)
                .GetAsync<CountryTestDetail>())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotZero(data.Id);
            Assert.IsNotEmpty(data.Name);
            Assert.NotNull(data.Currency);
            Assert.NotNull(data.Currency.Name);
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
            var code = "CZ";
            var currencyId = 1;
            var testDate = new DateTime(2018, 1, 1);
            var data = (await _client
                .List()
                .Filter(x => x.Code.IsEqual(code))
                .Filter(x => x.CurrencyId.IsEqual(currencyId))
                .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
                .Sort(x => x.Id.Desc())
                .GetAsync<CountryTestList>())
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.Code == code));
            Assert.True(data.Items.All(i => i.CurrencyId == currencyId));
            Assert.True(data.Items.All(i => i.DateLastChange > testDate));
        }
    }
}
