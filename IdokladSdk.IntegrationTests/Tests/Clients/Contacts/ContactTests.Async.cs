using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Contacts
{
    /// <summary>
    /// ContactTests.
    /// </summary>
    public partial class ContactTests
    {
        [Test]
        public async Task GetAsync_ReturnsList()
        {
            // Act
            var data = (await ContactClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
        }
    }
}
