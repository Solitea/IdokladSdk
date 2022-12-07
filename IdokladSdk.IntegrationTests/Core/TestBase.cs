using System;
using System.IO;
using System.Net.Http;
using IdokladSdk.Builders;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.IntegrationTests.Core.Builder;
using IdokladSdk.IntegrationTests.Core.Configuration;
using IdokladSdk.Response;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Core;

public class TestBase
{
    public DokladApi DokladApi { get; set; }

    public TestConfiguration Configuration { get; set; }

    protected HttpClient HttpClient { get; set; }

    public void InitDokladApi(Action<ApiResult> apiResultHandler = null, Action<ApiBatchResult> apiBatchResultHandler = null)
    {
        InitDokladApi<ClientCredentialsAuthProvider>(apiResultHandler, apiBatchResultHandler);
    }

    public void InitDokladApi<TAuthProvider>(Action<ApiResult> apiResultHandler = null, Action<ApiBatchResult> apiBatchResultHandler = null)
     where TAuthProvider : IAuthorizationProvider, new()
    {
        LoadConfiguration();
        HttpClient = new HttpClient();

        var builder = CreateBuilder<TAuthProvider>()
            .AddApiContextOptions(options =>
            {
                options.ApiResultHandler = apiResultHandler;
                options.ApiBatchResultHandler = apiBatchResultHandler;
            })
            .AddHttpClient(HttpClient);

        DokladApi = builder.Build();
    }

    [OneTimeTearDown]
    public void BaseTearDown()
    {
        HttpClient?.Dispose();
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
            .AddHttpClient(HttpClient);
    }
}
