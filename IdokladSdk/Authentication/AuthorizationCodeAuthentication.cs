using System;
using IdokladSdk.Authentication.Models;

namespace IdokladSdk.Authentication
{
    /// <summary>
    /// Authentication for grant type AuthorizationCode.
    /// </summary>
    public partial class AuthorizationCodeAuthentication : IAuthentication
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _code;
        private readonly string _redirectUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationCodeAuthentication"/> class.
        /// </summary>
        /// <param name="clientId">ClientId from Developer portal.</param>
        /// <param name="clientSecret">ClientSecret from Developer portal.</param>
        /// <param name="refreshToken">RefreshToken previously retrieved.</param>
        public AuthorizationCodeAuthentication(string clientId, string clientSecret, string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientId, nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientSecret, nameof(clientSecret));
            }

            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredRefreshToken, nameof(refreshToken));
            }

            _clientId = clientId;
            _clientSecret = clientSecret;
            RefreshToken = refreshToken;
            UseRefreshToken = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationCodeAuthentication"/> class.
        /// </summary>
        /// <param name="clientId">ClientId from Developer portal.</param>
        /// <param name="clientSecret">ClientSecret from Developer portal.</param>
        /// <param name="code">Code returned from Authorize enpoint of Identity Server.</param>
        /// <param name="redirectUri">URI where the code was returned to.</param>
        public AuthorizationCodeAuthentication(string clientId, string clientSecret, string code, string redirectUri)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientId, nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredClientSecret, nameof(clientSecret));
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredAuthenticationCode, nameof(code));
            }

            if (string.IsNullOrWhiteSpace(redirectUri))
            {
                throw new ArgumentException(AuthenticationMessageConstants.RequiredRedirectUri, nameof(redirectUri));
            }

            _clientId = clientId;
            _clientSecret = clientSecret;
            _code = code;
            _redirectUri = redirectUri;
        }

        /// <inheritdoc/>
        public string RefreshToken { get; protected set; }

        /// <inheritdoc/>
        public bool UseRefreshToken { get; set; }

        /// <inheritdoc/>
        public DokladConfiguration Configuration { get; set; }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public Tokenizer GetToken()
        {
            return GetTokenAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public Tokenizer RefreshAccessToken()
        {
            return RefreshAccessTokenAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public TokenRequest GetTokenRequest()
        {
            return PrepareTokenRequest();
        }

        /// <inheritdoc/>
        public TokenRequest GetRefreshAccessTokenRequest()
        {
            return PrepareRefreshTokenRequest();
        }

        private Tokenizer CopyCredentials(Tokenizer token)
        {
            RefreshToken = token.RefreshToken;

            token.ClientId = _clientId;
            token.ClientSecret = _clientSecret;
            token.RedirectUri = _redirectUri;

            return token;
        }

        private AuthorizationCodeTokenRequest PrepareTokenRequest()
        {
            return new AuthorizationCodeTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Code = _code,
                RedirectUri = _redirectUri
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
                GrantType = GrantType.AuthorizationCode,
                Scope = "idoklad_api offline_access"
            };
        }
    }
}
