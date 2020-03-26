using System;
using System.IO;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.IntegrationTests.Core.Configuration;
using IdokladSdk.Response;
using Microsoft.Extensions.Configuration;

namespace IdokladSdk.IntegrationTests.Core
{
    public class TestBase
    {
        public DokladApi DokladApi { get; set; }

        public TestConfiguration Configuration { get; set; }

        public void InitDokladApi(Action<ApiResult> apiResultHandler = null, Action<ApiBatchResult> apiBatchResultHandler = null)
        {
            InitDokladApi<ClientCredentialsAuthProvider>(apiResultHandler, apiBatchResultHandler);
        }

        public void InitDokladApi<TAuthProvider>(Action<ApiResult> apiResultHandler = null, Action<ApiBatchResult> apiBatchResultHandler = null)
         where TAuthProvider : IAuthorizationProvider, new()
        {
            LoadConfiguration();
            var context = CreateApiContext<TAuthProvider>();
            context.ApiResultHandler = apiResultHandler;
            context.ApiBatchResultHandler = apiBatchResultHandler;

            DokladApi = new DokladApi(context);
        }

        private void LoadConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testsettings.json")
                .AddJsonFile("localsettings.json", true)
                .Build();

            Configuration = configuration.Get<TestConfiguration>();
        }

        private ApiContext CreateApiContext<TAuthProvider>()
            where TAuthProvider : IAuthorizationProvider, new()
        {
            var auth = new TAuthProvider().GetAuthentication(Configuration);
            var dokladConfig = new DokladConfiguration(Configuration.Urls.ApiUrl, Configuration.Urls.IdentityServerTokenUrl);
            return new ApiContext("Tests", "1.0", auth, dokladConfig);
        }
    }
}
