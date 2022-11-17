using IdokladSdk.Authentication;
using IdokladSdk.Builders;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.IntegrationTests.Core.Configuration;

namespace IdokladSdk.IntegrationTests.Core.Builder;

internal class DokladApiTestBuilder : DokladApiBuilder
{
    private IAuthorizationProvider _authProvider;
    private TestConfiguration _configuration;

    internal DokladApiTestBuilder(string appName, string appVersion)
        : base(appName, appVersion)
    {
    }

    internal DokladApiTestBuilder AddAuthorizationProvider<TAuthProvider>(TestConfiguration configuration)
        where TAuthProvider : IAuthorizationProvider, new()
    {
        _authProvider = new TAuthProvider();
        _configuration = configuration;

        return this;
    }

    protected override IAuthentication GetAuthentication()
    {
        return _authProvider.GetAuthentication(_configuration);
    }
}
