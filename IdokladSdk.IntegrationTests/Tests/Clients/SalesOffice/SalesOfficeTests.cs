using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOffice
{
    /// <summary>
    /// SalesOfficeTests.
    /// </summary>
    public partial class SalesOfficeTests : TestBase
    {
        private const int SalesOfficeId = 12025;
        private SalesOfficeClient _salesOfficeClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _salesOfficeClient = DokladApi.SalesOfficeClient;
        }

        [Test]
        public void List_SuccessfullyGet()
        {
            // Act
            var data = _salesOfficeClient.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
        }

        [Test]
        public void Detail_SuccessfullyGet()
        {
            // Act
            var data = _salesOfficeClient.Detail(SalesOfficeId).Get().AssertResult();

            // Assert
            Assert.AreEqual(SalesOfficeId, data.Id);
            Assert.AreEqual("Sales office", data.Name);
            Assert.IsNull(data.Country);
        }

        [Test]
        public void Detail_Include_SuccessfullyGet()
        {
            // Act
            var data = _salesOfficeClient.Detail(SalesOfficeId).Include(i => i.Country).Get().AssertResult();

            // Assert
            Assert.AreEqual(SalesOfficeId, data.Id);
            Assert.AreEqual("Sales office", data.Name);
            Assert.NotNull(data.Country);
        }
    }
}
