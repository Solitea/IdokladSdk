using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.IntegrationTests.Core;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Authentication
{
    [TestFixture]
    public class TokenizerTests : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoadConfiguration();
        }

        [Test]
        public void Claims_ParsedSucessfully()
        {
            // Arrange
            var auth = new ClientCredentialsAuthentication(Configuration.ClientCredentials.ClientId, Configuration.ClientCredentials.ClientSecret);
            var config = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl);
            auth.Configuration = config;

            // Act
            var token = auth.GetToken();

            // Assert
            Assert.IsNotNull(token);
            Assert.That(token.Claims, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task Claims_ParsedSucessfullyAsync()
        {
            // Arrange
            var auth = new ClientCredentialsAuthentication(Configuration.ClientCredentials.ClientId, Configuration.ClientCredentials.ClientSecret);
            var config = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl);
            auth.Configuration = config;

            // Act
            var token = await auth.GetTokenAsync();

            // Assert
            Assert.IsNotNull(token);
            Assert.That(token.Claims, Is.Not.Null.Or.Empty);
        }
    }
}
