using System;
using IdokladSdk.Authentication.Extensions;
using IdokladSdk.Authentication.Models;
using RestSharp;

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
        public Tokenizer GetToken()
        {
            var client = new RestClient(Configuration.IdentityServerTokenUrl);
            var request = PrepareRequest();

            return client.RequestClientCredentialsToken(request);
        }

        /// <inheritdoc/>
        public Tokenizer RefreshAccessToken() => throw new NotSupportedException(AuthenticationMessageConstants.ClientCredetialsRefreshTokenNotSupported);

        private ClientCredentialsTokenRequest PrepareRequest()
        {
            return new ClientCredentialsTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret
            };
        }
    }
}
