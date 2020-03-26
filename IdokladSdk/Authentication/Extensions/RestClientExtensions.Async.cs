using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Models;
using RestSharp;

namespace IdokladSdk.Authentication.Extensions
{
    internal static partial class RestClientExtensions
    {
        internal static Task<Tokenizer> RequestAuthorizationCodeTokenAsync(this RestClient client, AuthorizationCodeTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, GrantType.AuthorizationCode, cancellationToken);
        }

        internal static Task<Tokenizer> RequestClientCredentialsTokenAsync(this RestClient client, ClientCredentialsTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, GrantType.ClientCredentials, cancellationToken);
        }

        internal static Task<Tokenizer> RequestPinTokenAsync(this RestClient client, PinTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, GrantType.Pin, cancellationToken);
        }

        internal static Task<Tokenizer> RequestRefreshTokenAsync(this RestClient client, RefreshTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, tokenRequest.GrantType, cancellationToken);
        }

        private static async Task<Tokenizer> ExecuteAsync(RestClient client, TokenRequest tokenRequest, GrantType grantType, CancellationToken cancellationToken = default)
        {
            var request = tokenRequest.ToRestRequest();
            var response = await client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

            return ProcessResponse(response, grantType);
        }
    }
}
