using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Extensions;
using RestSharp;

namespace IdokladSdk.Authentication
{
    public partial class PinAuthentication
    {
        /// <inheritdoc/>
        public async Task<Tokenizer> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            var client = new RestClient(Configuration.IdentityServerTokenUrl);
            var request = PrepareTokenRequest();

            var response = await client.RequestPinTokenAsync(request, cancellationToken).ConfigureAwait(false);

            return CopyCredentials(response);
        }

        /// <inheritdoc/>
        public async Task<Tokenizer> RefreshAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            var client = new RestClient(Configuration.IdentityServerTokenUrl);
            var request = PrepareRefreshTokenRequest();

            var response = await client.RequestRefreshTokenAsync(request, cancellationToken).ConfigureAwait(false);

            return CopyCredentials(response);
        }
    }
}
