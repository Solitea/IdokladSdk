using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Log
{
    /// <summary>
    /// LogTests.
    /// </summary>
    [TestFixture]
    public partial class LogTests : TestBase
    {
        private LogClient _logClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _logClient = DokladApi.LogClient;
        }

        [Test]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _logClient.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.Items.Count(), 0);
        }

        [Test]
        public void GetSpecificList_SuccessfullyReturned()
        {
            // Act
            var data = _logClient.List(913242, LogEntityType.IssuedInvoice).Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.Items.Count(), 0);
        }
    }
}
