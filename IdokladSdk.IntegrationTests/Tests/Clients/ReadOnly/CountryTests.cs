using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Country;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public class CountryTests : TestBase
    {
        private const int Id = 1;
        private CountryClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.CountryClient;
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
                .GetAsync<CountryTestDetail>()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Id, Is.Not.Zero);
            Assert.That(data.Name, Is.Not.Empty);
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
            var code = "CZ";
            var currencyId = 1;
            var testDate = new DateTime(2018, 1, 1);
            var data = await _client
                .List()
                .Filter(x => x.Code.IsEqual(code)
                            && x.CurrencyId.IsEqual(currencyId)
                            && x.DateLastChange.IsGreaterThan(testDate))
                .Sort(x => x.Id.Desc())
                .GetAsync<CountryTestList>()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items.All(i => i.Code == code), Is.True);
            Assert.That(data.Items.All(i => i.CurrencyId == currencyId), Is.True);
            Assert.That(data.Items.All(i => i.DateLastChange > testDate), Is.True);
        }
    }
}
