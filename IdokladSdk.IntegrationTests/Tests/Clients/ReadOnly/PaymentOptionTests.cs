using System;
using System.Linq;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.PaymentOption;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class PaymentOptionTests : TestBase
    {
        private const int Id = 3;
        private PaymentOptionClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.PaymentOptionClient;
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
            Assert.AreEqual(false, data.IsDefault);
            Assert.AreEqual(true, data.IsRounded);
        }

        [Test]
        public void Detail_WithParameters_SuccessfullyGet()
        {
            // Act
            var data = _client
                .Detail(Id)
                .Get<PaymentOptionTestDetail>()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotZero(data.Id);
            Assert.IsNotEmpty(data.Name);
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
            var testDate = new DateTime(2001, 1, 1);
            var data = _client
                .List()
                .Filter(x => x.DateLastChange.IsGreaterThan(testDate))
                .Sort(x => x.Id.Desc())
                .Get<PaymentOptionTestList>()
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.True(data.Items.All(i => i.DateLastChange > testDate));
            Assert.True(data.Items.First().Id > data.Items.Last().Id);
        }
    }
}
