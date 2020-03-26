using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.ExchangeRate;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class ExchangeRateTests : TestBase
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
                .GetAsync<ExchangeRateTestDetail>())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotZero(data.Amount);
            Assert.NotZero(data.CurrencyId);
            Assert.NotZero(data.ExchangeRateValue);
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
            var currencyId = 2;
            var testDate = new DateTime(2019, 1, 1);
            var exchangeListId = 2;
            var data = (await _client
                .List()
                .Filter(x => x.CurrencyId.IsEqual(currencyId))
                .Filter(x => x.Date.IsGreaterThan(testDate))
                .Filter(x => x.ExchangeListId.IsNotEqual(exchangeListId))
                .Sort(x => x.Id.Desc())
                .GetAsync<ExchangeRateTestList>())
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.CurrencyId == currencyId));
            Assert.True(data.Items.All(i => i.Date > testDate));
            Assert.True(data.Items.All(i => i.ExchangeListId != exchangeListId));
            Assert.True(data.Items.First().Id > data.Items.Last().Id);
        }
    }
}
