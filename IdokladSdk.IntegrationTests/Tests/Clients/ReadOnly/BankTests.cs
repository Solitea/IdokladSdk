using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Bank;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
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
                .Include(x => x.Country)
                .GetAsync<BankTestDetail>()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Id, Is.Not.Zero);
            Assert.That(data.Name, Is.Not.Empty);
            Assert.That(data.Country, Is.Not.Null);
            Assert.That(data.Country.Name, Is.Not.Null);
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
            // Arrange
            var countryId = 2;
            var testDate = new DateTime(2018, 1, 1);

            // Act
            var data = await _client
                .List()
                .Filter(x => x.CountryId.IsEqual(countryId))
                .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
                .Filter(x => x.IsOutOfDate.IsNotEqual(true))
                .Sort(x => x.Id.Desc())
                .GetAsync<BankTestList>()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items.All(i => i.CountryId == countryId), Is.True);
            Assert.That(data.Items.All(i => i.DateLastChange > testDate), Is.True);
            Assert.That(data.Items.All(i => !i.IsOutOfDate), Is.True);
            Assert.That(data.Items.First().Id > data.Items.Last().Id, Is.True);
        }
    }
}
