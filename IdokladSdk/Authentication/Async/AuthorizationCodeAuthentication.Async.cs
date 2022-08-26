using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Extensions;
using RestSharp;

namespace IdokladSdk.Authentication
{
    public partial class AuthorizationCodeAuthentication
    {
        /// <inheritdoc/>
        public async Task<Tokenizer> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            var client = new RestClient(Configuration.IdentityServerTokenUrl);
            var authRequest = PrepareTokenRequest();

            var tokenizer = await client.RequestAuthorizationCodeTokenAsync(authRequest, cancellationToken).ConfigureAwait(false);

            return CopyCredentials(tokenizer);
        }

        /// <inheritdoc/>
        public async Task<Tokenizer> RefreshAccessTokenAsync(RestClient restClient, CancellationToken cancellationToken = default)
        {
            var client = new RestClient(Configuration.IdentityServerTokenUrl);
            var authRequest = PrepareRefreshTokenRequest();

            var tokenizer = await client.RequestRefreshTokenAsync(authRequest, cancellationToken).ConfigureAwait(false);

            return CopyCredentials(tokenizer);
        }
    }
}
