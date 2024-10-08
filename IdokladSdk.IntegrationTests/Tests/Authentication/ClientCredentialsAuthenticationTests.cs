﻿using System.Net.Http;
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
            HttpClient = new HttpClient();
        }

        [Test]
        public async Task GetToken_SucessfullyAsync()
        {
            // Arrange
            var auth = new ClientCredentialsAuthentication(Configuration.ClientCredentials.ClientId, Configuration.ClientCredentials.ClientSecret, Configuration.ClientCredentials.ApplicationId);
            var config = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerUrl);
            auth.Configuration = config;

            // Act
            var token = await auth.GetTokenAsync(HttpClient);

            // Assert
            Assert.That(token, Is.Not.Null);
            Assert.That(token.AccessToken, Is.Not.Null.Or.Empty);
        }
    }
}
