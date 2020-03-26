using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOffice
{
    /// <summary>
    /// SalesOfficeTests.
    /// </summary>
    public partial class SalesOfficeTests
    {
        [Test]
        public async Task ListAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _salesOfficeClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
        }

        [Test]
        public async Task DetailAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _salesOfficeClient.Detail(SalesOfficeId).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(SalesOfficeId, data.Id);
            Assert.AreEqual("Sales office", data.Name);
            Assert.IsNull(data.Country);
        }

        [Test]
        public async Task DetailAsync_Include_SuccessfullyGet()
        {
            // Act
            var data = (await _salesOfficeClient.Detail(SalesOfficeId).Include(i => i.Country).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(SalesOfficeId, data.Id);
            Assert.AreEqual("Sales office", data.Name);
            Assert.NotNull(data.Country);
        }
    }
}
