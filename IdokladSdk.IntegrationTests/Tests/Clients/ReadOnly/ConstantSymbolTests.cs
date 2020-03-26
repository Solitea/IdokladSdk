using System;
using System.Linq;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.ConstantSymbol;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class ConstantSymbolTests : TestBase
    {
        private const int Id = 7;
        private ConstantSymbolClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.ConstantSymbolClient;
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
            Assert.True(data.IsDefault);
        }

        [Test]
        public void Detail_WithParameters_SuccessfullyGet()
        {
            // Act
            var data = _client
                .Detail(Id)
                .Include(x => x.Country)
                .Get<ConstantSymbolTestDetail>()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotZero(data.Id);
            Assert.IsNotEmpty(data.Name);
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
            var testDate = new DateTime(2001, 1, 1);
            var data = _client
                .List()
                .Filter(x => x.CountryId.IsEqual(countryId))
                .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
                .Sort(x => x.Id.Desc())
                .Get<ConstantSymbolTestList>()
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.CountryId == countryId));
            Assert.True(data.Items.All(i => i.DateLastChange > testDate));
        }
    }
}
