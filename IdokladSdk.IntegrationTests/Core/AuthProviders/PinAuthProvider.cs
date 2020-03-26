using IdokladSdk.Authentication;
using IdokladSdk.IntegrationTests.Core.Configuration;

namespace IdokladSdk.IntegrationTests.Core.AuthProviders
{
    public class PinAuthProvider : IAuthorizationProvider
    {
        public IAuthentication GetAuthentication(TestConfiguration config)
        {
            return new PinAuthentication(
                config.PinFlow.ClientId,
                config.PinFlow.ClientSecret,
                config.PinFlow.Pin,
                config.PinFlow.RefreshToken);
        }
    }
}
