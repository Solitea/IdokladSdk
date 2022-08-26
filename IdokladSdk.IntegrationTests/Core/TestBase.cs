using System;
using System.IO;
using System.Net.Http;
using IdokladSdk.Builders;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.IntegrationTests.Core.Builder;
using IdokladSdk.IntegrationTests.Core.Configuration;
using IdokladSdk.Response;
using Microsoft.Extensions.Configuration;

namespace IdokladSdk.IntegrationTests.Core
{
    public class TestBase
    {
        public DokladApi DokladApi { get; set; }

        public TestConfiguration Configuration { get; set; }

        protected HttpClient ApiHttpClient { get; set; }

        protected HttpClient IdentityHttpClient { get; set; }

        public void InitDokladApi(Action<ApiResult> apiResultHandler = null, Action<ApiBatchResult> apiBatchResultHandler = null)
        {
            InitDokladApi<ClientCredentialsAuthProvider>(apiResultHandler, apiBatchResultHandler);
        }

        public void InitDokladApi<TAuthProvider>(Action<ApiResult> apiResultHandler = null, Action<ApiBatchResult> apiBatchResultHandler = null)
         where TAuthProvider : IAuthorizationProvider, new()
        {
            LoadConfiguration();

            var builder = CreateBuilder<TAuthProvider>();
            builder.AddApiContextOptions(options =>
            {
                options.ApiResultHandler = apiResultHandler;
                options.ApiBatchResultHandler = apiBatchResultHandler;
            });

            DokladApi = builder.Build();
        }

        protected void LoadConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testsettings.json")
                .AddJsonFile("localsettings.json", true)
                .Build();

            Configuration = configuration.Get<TestConfiguration>();
        }

        private DokladApiBuilder CreateBuilder<TAuthProvider>()
            where TAuthProvider : IAuthorizationProvider, new()
        {
            return new DokladApiTestBuilder("Tests", "1.0")
                .AddAuthorizationProvider<TAuthProvider>(Configuration)
                .AddCustomApiUrls(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl)
                .AddHttpClientForApi(ApiHttpClient);
        }
    }
}
