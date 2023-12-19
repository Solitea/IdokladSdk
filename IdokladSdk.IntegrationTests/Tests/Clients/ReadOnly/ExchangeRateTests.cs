using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.ExchangeRate;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public class ExchangeRateTests : TestBase
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
        public async Task DetailAsync_SuccessfullyGet()
        {
            // Act
            var data = await _client
                .Detail(Id)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            AssertionsHelper.AssertDetail(data);
        }

        [Test]
        public async Task DetailAsync_WithParameters_SuccessfullyGet()
        {
            // Act
            var data = await _client
                .Detail(Id)
                .Include(x => x.Currency)
                .GetAsync<ExchangeRateTestDetail>()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Amount, Is.Not.Zero);
            Assert.That(data.CurrencyId, Is.Not.Zero);
            Assert.That(data.ExchangeRateValue, Is.Not.Zero);
            Assert.That(data.Currency, Is.Not.Null);
            Assert.That(data.Currency.Name, Is.Not.Null);
        }

        [Test]
        public async Task ListAsync_ReturnsNonEmptyList()
        {
            // Act
            var data = await _client
                .List()
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
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
            var data = await _client
                .List()
                .Filter(x => x.CurrencyId.IsEqual(currencyId))
                .Filter(x => x.Date.IsGreaterThan(testDate))
                .Filter(x => x.ExchangeListId.IsNotEqual(exchangeListId))
                .Sort(x => x.Id.Desc())
                .GetAsync<ExchangeRateTestList>()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items.All(i => i.CurrencyId == currencyId), Is.True);
            Assert.That(data.Items.All(i => i.Date > testDate), Is.True);
            Assert.That(data.Items.All(i => i.ExchangeListId != exchangeListId), Is.True);
            Assert.That(data.Items.First().Id > data.Items.Last().Id, Is.True);
        }
    }
}
