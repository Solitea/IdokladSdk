using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Models;
using IdokladSdk.Exceptions;
using Newtonsoft.Json;

namespace IdokladSdk.Authentication.Extensions
{
    /// <summary>
    /// IdokladSdk extensions for HttpClient.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Send request.
        /// </summary>
        /// <param name="client">HttpClient.</param>
        /// <param name="tokenRequest">Token request for execution.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Instance of <see cref="Tokenizer"/>.</returns>
        public static Task<Tokenizer> SendRequestAsync(this HttpClient client, TokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(client, tokenRequest, cancellationToken);
        }

        private static async Task<Tokenizer> ExecuteAsync(HttpClient client, TokenRequest tokenRequest, CancellationToken cancellationToken = default)
        {
            var request = tokenRequest.ToHttpRequestMessage();
            var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);

            return await ProcessResponseAsync(response, tokenRequest.GrantType).ConfigureAwait(false);
        }

        private static async Task<Tokenizer> ProcessResponseAsync(HttpResponseMessage response, GrantType grantType)
        {
            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                throw new IdokladUnavailableException(response);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new IdokladAuthorizationException(response);
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var tokenizer = JsonConvert.DeserializeObject<Tokenizer>(content);
            tokenizer.GrantType = grantType;

            if (string.IsNullOrEmpty(tokenizer.AccessToken))
            {
                var authResponse = JsonConvert.DeserializeObject<AuthenticationError>(content);
                throw new IdokladAuthenticationException(authResponse);
            }

            return tokenizer;
        }
    }
}
