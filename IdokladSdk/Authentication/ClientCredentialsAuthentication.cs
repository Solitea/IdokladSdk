using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Extensions;
using IdokladSdk.Authentication.Models;

namespace IdokladSdk.Authentication
{
    /// <summary>
    /// Authentication for grant type ClientCredentials.
    /// </summary>
    public partial class ClientCredentialsAuthentication : IAuthentication
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientCredentialsAuthentication"/> class.
        /// </summary>
        /// <param name="clientId">ClientId from iDoklad.</param>
        /// <param name="clientSecret">ClientSecret from iDoklad.</param>
        public ClientCredentialsAuthentication(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientId, nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientSecret, nameof(clientSecret));
            }

            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        /// <inheritdoc/>
        public string RefreshToken
        {
            get => null;
            protected set => throw new NotSupportedException(AuthenticationMessageConstants.ClientCredetialsRefreshTokenNotSupported);
        }

        /// <inheritdoc/>
        public bool UseRefreshToken
        {
            get => false;
            set => throw new NotSupportedException(AuthenticationMessageConstants.ClientCredetialsRefreshTokenNotSupported);
        }

        /// <inheritdoc/>
        public DokladConfiguration Configuration { get; set; }

        /// <inheritdoc/>
        public async Task<Tokenizer> GetTokenAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
        {
            var request = PrepareRequest();
            var tokenizer = await httpClient.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return tokenizer;
        }

        /// <inheritdoc/>
        public Task<Tokenizer> RefreshAccessTokenAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(AuthenticationMessageConstants.ClientCredetialsRefreshTokenNotSupported);
        }

        private ClientCredentialsTokenRequest PrepareRequest()
        {
            return new ClientCredentialsTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                IdentityServerTokenUrl = Configuration.IdentityServerTokenUrl
            };
        }
    }
}
