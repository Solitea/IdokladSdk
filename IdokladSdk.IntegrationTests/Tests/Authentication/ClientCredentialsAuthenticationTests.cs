using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.IntegrationTests.Core;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Authentication
{
    public class ClientCredentialsAuthenticationTests : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            LoadConfiguration();
        }

        [Test]
        public void GetToken_Sucessfully()
        {
            // Arrange
            var auth = new ClientCredentialsAuthentication(Configuration.ClientCredentials.ClientId, Configuration.ClientCredentials.ClientSecret);
            var config = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl);
            auth.Configuration = config;

            // Act
            var token = auth.GetToken();

            // Assert
            Assert.IsNotNull(token);
            Assert.That(token.AccessToken, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetToken_SucessfullyAsync()
        {
            // Arrange
            var auth = new ClientCredentialsAuthentication(Configuration.ClientCredentials.ClientId, Configuration.ClientCredentials.ClientSecret);
            var config = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl);
            auth.Configuration = config;

            // Act
            var token = await auth.GetTokenAsync();

            // Assert
            Assert.IsNotNull(token);
            Assert.That(token.AccessToken, Is.Not.Null.Or.Empty);
        }
    }
}
