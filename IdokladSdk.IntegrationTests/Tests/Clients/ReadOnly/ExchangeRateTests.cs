using System;
using System.Linq;
using IdokladSdk.Clients.Readonly;
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
        private const int Id = 2;
        private ExchangeRateClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.ExchangeRateClient;
        }

        [Test]
        public void Detail_SuccessfullyGet()
        {
            // Act
            var data = _client
                .Detail(Id)
                .Get()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            AssertionsHelper.AssertDetail(data);
        }

        [Test]
        public void Detail_WithParameters_SuccessfullyGet()
        {
            // Act
            var data = _client
                .Detail(Id)
                .Include(x => x.Currency)
                .Get<ExchangeRateTestDetail>()
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
        public void List_ReturnsNonEmptyList()
        {
            // Act
            var data = _client
                .List()
                .Get()
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            var firstItem = data.Items.First();
            AssertionsHelper.AssertDetail(firstItem);
        }

        [Test]
        public void List_WithParameters_ReturnsCorrectResult()
        {
            // Act
            var currencyId = 2;
            var testDate = new DateTime(2019, 1, 1);
            var exchangeListId = 2;
            var data = _client
                .List()
                .Filter(x => x.CurrencyId.IsEqual(currencyId))
                .Filter(x => x.Date.IsGreaterThan(testDate))
                .Filter(x => x.ExchangeListId.IsNotEqual(exchangeListId))
                .Sort(x => x.Id.Desc())
                .Get<ExchangeRateTestList>()
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
