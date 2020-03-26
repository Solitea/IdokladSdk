using IdokladSdk.Authentication;
using IdokladSdk.IntegrationTests.Core.Configuration;

namespace IdokladSdk.IntegrationTests.Core.AuthProviders
{
    public interface IAuthorizationProvider
    {
        IAuthentication GetAuthentication(TestConfiguration config);
    }
}
