using System;
using System.Linq;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.VatCode;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class VatCodeTests : TestBase
    {
        private const int Id = 1;
        private VatCodeClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.VatCodeClient;
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

                // .Include(x => x.Country)
                .Get<VatCodeTestDetail>()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data.Code);
            Assert.IsNotEmpty(data.Name);

            // Assert.NotNull(data.Country);
            // Assert.NotNull(data.Country.Name);
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
            var data = _client
                .List()
                .Filter(x => x.CountryId.IsEqual(countryId))
                .Filter(x => x.DateValidityFrom.IsLowerThanOrEqual(testDate))
                .Filter(x => x.DateValidityTo.IsGreaterThanOrEqual(testDate))
                .Sort(x => x.Id.Desc())
                .Get<VatCodeTestList>()
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.CountryId == countryId));
            Assert.True(data.Items.All(i => i.DateValidityFrom <= testDate));
            Assert.True(data.Items.All(i => i.DateValidityTo >= testDate));
        }
    }
}
