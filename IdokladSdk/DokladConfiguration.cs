using System;

namespace IdokladSdk
{
    /// <summary>
    /// Configuration variables for iDoklad SDK.
    /// </summary>
    public class DokladConfiguration
    {
        private const string TokenEndpoint = "server/v2/connect/token";

        /// <summary>
        /// Initializes a new instance of the <see cref="DokladConfiguration"/> class.
        /// </summary>
        public DokladConfiguration()
        {
            ApiUrl = new Uri($"https://api.idoklad.cz/{Constants.ApiVersion}");
            IdentityServerTokenUrl = new Uri("https://identity.idoklad.cz/server/v2/connect/token");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DokladConfiguration"/> class.
        /// </summary>
        /// <param name="apiUrl">URL of iDoklad API.</param>
        /// <param name="identityServerUrl">URL of Identity server.</param>
        public DokladConfiguration(string apiUrl, string identityServerUrl)
        {
            var identityServerUri = CheckUrl(identityServerUrl, nameof(identityServerUrl));
            IdentityServerTokenUrl = BuildTokenUrl(identityServerUri, TokenEndpoint);

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

        private Uri BuildTokenUrl(Uri uri, string tokenEndpoint)
        {
            var builder = new UriBuilder(uri);
            builder.Path += tokenEndpoint;
            return builder.Uri;
        }
    }
}
