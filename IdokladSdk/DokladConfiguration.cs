using System;

namespace IdokladSdk
{
    /// <summary>
    /// Configuration variables for iDoklad SDK.
    /// </summary>
    public class DokladConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DokladConfiguration"/> class.
        /// </summary>
        public DokladConfiguration()
        {
            ApiUrl = new Uri($"https://api.idoklad.cz/{Constants.ApiVersion}");
            IdentityServerTokenUrl = new Uri("https://identity.idoklad.cz/server/connect/token");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DokladConfiguration"/> class.
        /// </summary>
        /// <param name="apiUrl">URL of iDoklad API.</param>
        /// <param name="identityServerTokenUrl">URL of token endpoint of Identity server.</param>
        public DokladConfiguration(string apiUrl, string identityServerTokenUrl)
        {
            IdentityServerTokenUrl = CheckUrl(identityServerTokenUrl, nameof(identityServerTokenUrl));
            var apiUri = CheckUrl(apiUrl, nameof(apiUrl));

            ApiUrl = new Uri(apiUri, Constants.ApiVersion);
        }

        /// <summary>
        /// Gets URL of iDoklad API.
        /// </summary>
        public Uri ApiUrl { get; }

        /// <summary>
        /// Gets URL of token endpoint of Identity server.
        /// </summary>
        public Uri IdentityServerTokenUrl { get; }

        private Uri CheckUrl(string url, string paramName)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be null or empty.", paramName);
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new ArgumentException("URL is invalid and has to be absolute.", paramName);
            }

            return uri;
        }
    }
}
