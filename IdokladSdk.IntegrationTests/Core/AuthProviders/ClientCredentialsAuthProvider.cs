using IdokladSdk.Authentication;
using IdokladSdk.IntegrationTests.Core.Configuration;

namespace IdokladSdk.IntegrationTests.Core.AuthProviders
{
    public class ClientCredentialsAuthProvider : IAuthorizationProvider
    {
        public IAuthentication GetAuthentication(TestConfiguration config)
        {
            return new ClientCredentialsAuthentication(config.ClientCredentials.ClientId, config.ClientCredentials.ClientSecret, config.ClientCredentials.ApplicationId);
        }
    }
}
