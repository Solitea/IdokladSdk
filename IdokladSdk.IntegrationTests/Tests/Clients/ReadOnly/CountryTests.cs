using System;
using System.Linq;
using IdokladSdk.Clients.Readonly;
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
        private const int Id = 1;
        private CountryClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.CountryClient;
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
                .Get<CountryTestDetail>()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotZero(data.Id);
            Assert.IsNotEmpty(data.Name);
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
            Assert.True(data.Items.Any(c => c.IsEuMember));
            var firstItem = data.Items.First();
            AssertionsHelper.AssertDetail(firstItem);
        }

        [Test]
        public void List_WithParameters_ReturnsCorrectResult()
        {
            // Act
            var code = "CZ";
            var currencyId = 1;
            var testDate = new DateTime(2018, 1, 1);
            var data = _client
                .List()
                .Filter(x => x.Code.IsEqual(code))
                .Filter(x => x.CurrencyId.IsEqual(currencyId))
                .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
                .Sort(x => x.Id.Desc())
                .Get<CountryTestList>()
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
