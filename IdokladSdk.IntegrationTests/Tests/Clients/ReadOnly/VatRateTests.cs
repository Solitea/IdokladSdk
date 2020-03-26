using System;
using System.Linq;
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
    public partial class VatRateTests : TestBase
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
            Assert.AreEqual(VatRateType.Basic, data.RateType);
        }

        [Test]
        public void Detail_WithParameters_SuccessfullyGet()
        {
            // Act
            var data = _client
                .Detail(Id)
                .Include(x => x.Country)
                .Get<VatRateTestDetail>()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotZero(data.Id);
            Assert.IsNotEmpty(data.Name);
            Assert.NotZero(data.Rate);
            Assert.NotNull(data.Country);
            Assert.NotNull(data.Country.Name);
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
            var countryId = 2;
            var testDate = new DateTime(2018, 1, 1);
            var rateType = VatRateType.Basic;
            var data = _client
                .List()
                .Filter(x => x.CountryId.IsEqual(countryId))
                .Filter(x => x.DateValidityFrom.IsLowerThanOrEqual(testDate))
                .Filter(x => x.DateValidityTo.IsGreaterThanOrEqual(testDate))
                .Filter(x => x.RateType.IsEqual(rateType))
                .Sort(x => x.Id.Desc())
                .Get<VatRateTestList>()
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.CountryId == countryId));
            Assert.True(data.Items.All(i => i.DateValidityFrom <= testDate));
            Assert.True(data.Items.All(i => i.DateValidityTo >= testDate));
            Assert.True(data.Items.All(i => i.RateType == rateType));
        }
    }
}
