using System.Net.Http;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.IntegrationTests.Core;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Authentication;

public class PinAuthenticationTests : TestBase
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        LoadConfiguration();
        HttpClient = new HttpClient();
    }

    [Test]
    public async Task GetToken_SucessfullyAsync()
    {
        // Arrange
        var auth = new PinAuthentication(Configuration.PinFlow.ClientId, Configuration.PinFlow.ClientSecret, Configuration.PinFlow.Pin, Configuration.PinFlow.RefreshToken);
        var config = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl);
        auth.Configuration = config;

        // Act
        var token = await auth.RefreshAccessTokenAsync(HttpClient);

        // Assert
        Assert.IsNotNull(token);
        Assert.That(token.AccessToken, Is.Not.Null.Or.Empty);
    }
}
