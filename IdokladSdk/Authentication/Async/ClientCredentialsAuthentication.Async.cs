using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Extensions;
using RestSharp;

namespace IdokladSdk.Authentication
{
    public partial class ClientCredentialsAuthentication
    {
        /// <inheritdoc/>
        public async Task<Tokenizer> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            var client = new RestClient();
            var request = PrepareRequest();

            return await client.RequestClientCredentialsTokenAsync(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Task<Tokenizer> RefreshAccessTokenAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(AuthenticationMessageConstants.ClientCredetialsRefreshTokenNotSupported);
    }
}
