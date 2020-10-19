using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Models;
using RestSharp;

namespace IdokladSdk.Authentication.Extensions
{
    internal static partial class RestClientExtensions
    {
        internal static Task<Tokenizer> RequestAuthorizationCodeTokenAsync(this IRestClient client, AuthorizationCodeTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, GrantType.AuthorizationCode, cancellationToken);
        }

        internal static Task<Tokenizer> RequestClientCredentialsTokenAsync(this IRestClient client, ClientCredentialsTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, GrantType.ClientCredentials, cancellationToken);
        }

        internal static Task<Tokenizer> RequestPinTokenAsync(this IRestClient client, PinTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, GrantType.Pin, cancellationToken);
        }

        internal static Task<Tokenizer> RequestRefreshTokenAsync(this IRestClient client, RefreshTokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, tokenRequest.GrantType, cancellationToken);
        }

        private static async Task<Tokenizer> ExecuteAsync(IRestClient client, TokenRequest tokenRequest, GrantType grantType, CancellationToken cancellationToken = default)
        {
            var request = tokenRequest.ToRestRequest();
            var response = await client.ExecuteAsync(request, request.Method, cancellationToken).ConfigureAwait(false);

            return ProcessResponse(response, grantType);
        }
    }
}
