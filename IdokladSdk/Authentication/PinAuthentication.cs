using System;
using IdokladSdk.Authentication.Models;

namespace IdokladSdk.Authentication
{
    /// <summary>
    /// Authentication for grant type Pin.
    /// </summary>
    public partial class PinAuthentication : IAuthentication
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _pin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PinAuthentication"/> class.
        /// </summary>
        /// <param name="clientId">ClientId from Developer portal.</param>
        /// <param name="clientSecret">ClientSecret from Developer portal.</param>
        /// <param name="pin">Pin from iDoklad.</param>
        /// <param name="refreshToken">RefreshToken previously retrieved.</param>
        public PinAuthentication(string clientId, string clientSecret, string pin = null, string refreshToken = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientId, nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientSecret, nameof(clientSecret));
            }

            if (string.IsNullOrWhiteSpace(pin) && string.IsNullOrWhiteSpace(refreshToken))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredPinOrRefreshToken, $"{nameof(pin)}/{nameof(refreshToken)}");
            }

            _clientId = clientId;
            _clientSecret = clientSecret;
            _pin = pin;
            RefreshToken = refreshToken;

            UseRefreshToken = !string.IsNullOrWhiteSpace(refreshToken);
        }

        /// <inheritdoc/>
        public string RefreshToken { get; protected set; }

        /// <inheritdoc/>
        public bool UseRefreshToken { get; set; }

        /// <inheritdoc/>
        public DokladConfiguration Configuration { get; set; }

        /// <inheritdoc/>
        public TokenRequest GetTokenRequest()
        {
            return PrepareTokenRequest();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public Tokenizer GetToken()
        {
            return GetTokenAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public TokenRequest GetRefreshAccessTokenRequest()
        {
            return PrepareRefreshTokenRequest();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public Tokenizer RefreshAccessToken()
        {
            return RefreshAccessTokenAsync().GetAwaiter().GetResult();
        }

        private Tokenizer CopyCredentials(Tokenizer token)
        {
            RefreshToken = token.RefreshToken;

            token.GrantType = GrantType.Pin;
            token.ClientId = _clientId;
            token.ClientSecret = _clientSecret;

            return token;
        }

        private PinTokenRequest PrepareTokenRequest()
        {
            return new PinTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Pin = _pin
            };
        }

        private RefreshTokenRequest PrepareRefreshTokenRequest()
        {
            if (string.IsNullOrWhiteSpace(RefreshToken))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredRefreshToken);
            }

            return new RefreshTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                RefreshToken = RefreshToken,
                GrantType = GrantType.Pin,
                Scope = "eet offline_access"
            };
        }
    }
}
