using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.VatRate;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public class VatRateTests : TestBase
    {
        private const int Id = 1;
        private VatRateClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.VatRateClient;
        }

        [Test]
        public async Task DetailAsync_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client
                .Detail(Id)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            AssertionsHelper.AssertDetail(data);
            Assert.That(data.RateType, Is.EqualTo(VatRateType.Basic));
        }

        [Test]
        public async Task DetailAsync_WithParameters_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client
                .Detail(Id)
                .Include(x => x.Country)
                .GetAsync<VatRateTestDetail>()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Id, Is.Not.Zero);
            Assert.That(data.Name, Is.Not.Empty);
            Assert.That(data.Rate, Is.Not.Zero);
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
            // Act
            var countryId = 2;
            var testDate = new DateTime(2018, 1, 1);
            var rateType = VatRateType.Basic;
            var data = await _client
                .List()
                .Filter(x => x.CountryId.IsEqual(countryId)
                            && x.DateValidityFrom.IsLowerThanOrEqual(testDate)
                            && x.DateValidityTo.IsGreaterThanOrEqual(testDate)
                            && x.RateType.IsEqual(rateType))
                .Sort(x => x.Id.Desc())
                .GetAsync<VatRateTestList>()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items.All(i => i.CountryId == countryId), Is.True);
            Assert.That(data.Items.All(i => i.DateValidityFrom <= testDate), Is.True);
            Assert.That(data.Items.All(i => i.DateValidityTo >= testDate), Is.True);
            Assert.That(data.Items.All(i => i.RateType == rateType), Is.True);
        }
    }
}
