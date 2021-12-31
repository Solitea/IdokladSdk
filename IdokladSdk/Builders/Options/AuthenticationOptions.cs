using IdokladSdk.Authentication;

namespace IdokladSdk.Builders.Options
{
    /// <summary>
    /// AuthenticationOptions.
    /// </summary>
    public class AuthenticationOptions
    {
        /// <summary>
        /// Gets or sets ClientId.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets ClientSecret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets GrantType.
        /// </summary>
        public GrantType? GrantType { get; set; }

        /// <summary>
        /// Gets or sets RefreshToken.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets AuthorizationCode.
        /// </summary>
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets Pin.
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Gets or sets RedirectUri.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets a value indicating whether UseRefreshToken.
        /// </summary>
        public bool UseRefreshToken => GrantType == Authentication.GrantType.AuthorizationCode && !string.IsNullOrWhiteSpace(RefreshToken);
    }
}
