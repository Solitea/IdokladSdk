using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication.Models;

namespace IdokladSdk.Authentication
{
    /// <summary>
    /// Authentication for iDoklad API.
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Gets or sets configuration.
        /// </summary>
        DokladConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets refresh token.
        /// </summary>
        string RefreshToken { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to use RefreshToken after creating this object.
        /// </summary>
        bool UseRefreshToken { get; set; }

        /// <summary>
        /// Request new token.
        /// </summary>
        /// <returns>Token.</returns>
        /// <exception cref="AuthenticationException">Authentication is unsuccessful.</exception>
        [Obsolete("Use async method instead.")]
        Tokenizer GetToken();

        /// <summary>
        /// Request new token.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Token.</returns>
        /// <exception cref="AuthenticationException">Authentication is unsuccessful.</exception>
        Task<Tokenizer> GetTokenAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get token request.
        /// </summary>
        /// <returns>AuthorizationCodeTokenRequest.</returns>
        TokenRequest GetTokenRequest();

        /// <summary>
        /// Get refresh access token request.
        /// </summary>
        /// <returns>RefreshTokenRequest.</returns>
        TokenRequest GetRefreshAccessTokenRequest();

        /// <summary>
        /// Refresh existing token using refresh token.
        /// </summary>
        /// <returns>Token.</returns>
        /// <exception cref="AuthenticationException">Authentication is unsuccessful.</exception>
        [Obsolete("Use async method instead.")]
        Tokenizer RefreshAccessToken();

        /// <summary>
        /// Refresh existing token using refresh token.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Token.</returns>
        /// <exception cref="AuthenticationException">Authentication is unsuccessful.</exception>
        Task<Tokenizer> RefreshAccessTokenAsync(CancellationToken cancellationToken = default);
    }
}
