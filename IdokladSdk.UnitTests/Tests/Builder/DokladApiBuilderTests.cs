using System;
using System.Net.Http;
using IdokladSdk.Builders;
using IdokladSdk.Enums;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Builder
{
    [TestFixture]
    public class DokladApiBuilderTests
    {
        private const string AppName = "test";
        private const string AppVersion = "1.0";
        private const string ClientId = "clientId";
        private const string ClientSecret = "clientSecret";
        private HttpClient _httpClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _httpClient = new HttpClient();
        }

        [Test]
        public void MissingAuthentication_Throws()
        {
            // Arrange
            var builder = new DokladApiBuilder(AppName, AppVersion);

            // Assert
            Assert.That(() => builder.Build(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void NoCustomUrls_UsesDefault()
        {
            // Arrange
            var defaultConfiguration = new DokladConfiguration();
            var api = new DokladApiBuilder(AppName, AppVersion)
                .AddClientCredentialsAuthentication(ClientId, ClientSecret)
                .AddHttpClientForApi(_httpClient)
                .Build();

            // Assert
            Assert.AreEqual(defaultConfiguration.ApiUrl.ToString(), api.ApiContext.Configuration.ApiUrl.ToString());
            Assert.AreEqual(defaultConfiguration.IdentityServerTokenUrl.ToString(), api.ApiContext.Configuration.IdentityServerTokenUrl.ToString());
        }

        [Test]
        public void CustomUrls_UsesCustom()
        {
            // Arrange
            var apiUrl = $"https://customapi.url/{Constants.ApiVersion}";
            var identityServerUrl = "https://customidentityserver.url/";
            var defaultConfiguration = new DokladConfiguration();
            var api = new DokladApiBuilder(AppName, AppVersion)
                .AddClientCredentialsAuthentication(ClientId, ClientSecret)
                .AddCustomApiUrls(apiUrl, identityServerUrl)
                .AddHttpClientForApi(_httpClient)
                .Build();

            // Assert
            Assert.AreNotEqual(defaultConfiguration.ApiUrl.ToString(), api.ApiContext.Configuration.ApiUrl.ToString());
            Assert.AreNotEqual(defaultConfiguration.IdentityServerTokenUrl.ToString(), api.ApiContext.Configuration.IdentityServerTokenUrl.ToString());
            Assert.AreEqual(apiUrl, api.ApiContext.Configuration.ApiUrl.ToString());
            Assert.AreEqual(identityServerUrl, api.ApiContext.Configuration.IdentityServerTokenUrl.ToString());
        }

        [TestCase(Language.Cz, "cs-CZ")]
        [TestCase(Language.Sk, "sk-SK")]
        [TestCase(Language.De, "de-DE")]
        [TestCase(Language.En, "en-US")]
        public void ApiContext_LanguageSet_UsesCorrectLanguage(Language language, string languageCode)
        {
            // Arrange
            var api = new DokladApiBuilder(AppName, AppVersion)
                .AddClientCredentialsAuthentication(ClientId, ClientSecret)
                .AddApiContextOptions(options =>
                {
                    options.Language = language;
                })
                .AddHttpClientForApi(_httpClient)
                .Build();

            // Assert
            Assert.AreEqual(languageCode, api.ApiContext.Headers["Accept-Language"]);
        }

        [Test]
        public void ApiContext_ResultHandlers_CorrectllySet()
        {
            // Arrange
            Action<ApiResult> apiResultHandler = (ApiResult result) => { };
            Action<ApiResult> apiResultHandler2 = (ApiResult result) => { };
            Action<ApiBatchResult> apiBatchResultHandler = (ApiBatchResult result) => { };

            var api = new DokladApiBuilder(AppName, AppVersion)
                .AddClientCredentialsAuthentication(ClientId, ClientSecret)
                .AddApiContextOptions(options =>
                {
                    options.ApiResultHandler = apiResultHandler;
                    options.ApiBatchResultHandler = apiBatchResultHandler;
                })
                .AddHttpClientForApi(_httpClient)
                .Build();

            // Assert
            Assert.AreEqual(apiResultHandler, api.ApiContext.ApiResultHandler);
            Assert.AreNotEqual(apiResultHandler2, api.ApiContext.ApiResultHandler);
            Assert.AreEqual(apiBatchResultHandler, api.ApiContext.ApiBatchResultHandler);
        }
    }
}
