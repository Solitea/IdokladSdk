using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Currency;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public class CurrencyTests : TestBase
    {
        private const int Id = 1;
        private CurrencyClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.CurrencyClient;
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
            Assert.NotZero(data.Priority);
        }

        [Test]
        public async Task DetailAsync_WithParameters_SuccessfullyGet()
        {
            // Act
            var data = (await _client
                .Detail(Id)
                .GetAsync<CurrencyTestDetail>())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data.Code);
            Assert.NotZero(data.Id);
            Assert.IsNotEmpty(data.Name);
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
            var code = "CZK";
            var testDate = new DateTime(2001, 1, 1);
            var data = (await _client
                .List()
                .Filter(x => x.Code.IsEqual(code))
                .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
                .Sort(x => x.Id.Desc())
                .GetAsync<CurrencyTestList>())
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.Code == code));
        }
    }
}