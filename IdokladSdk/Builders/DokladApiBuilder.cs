using System;
using IdokladSdk.Authentication;
using IdokladSdk.Builders.Options;
using IdokladSdk.Enums;
using IdokladSdk.Exceptions;

namespace IdokladSdk.Builders
{
    /// <summary>
    /// Builder for iDoklad API.
    /// </summary>
    public class DokladApiBuilder
    {
        private readonly string _appName;
        private readonly string _appVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="DokladApiBuilder"/> class.
        /// </summary>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        public DokladApiBuilder(string appName, string appVersion)
        {
            _appName = appName;
            _appVersion = appVersion;
        }

        /// <summary>
        /// Gets or sets provider of AuthenticationOptions.
        /// </summary>
        protected Func<AuthenticationOptions> AuthenticationOptionsProvider { get; set; }

        /// <summary>
        /// Gets or sets provider of ApiContextOptionsProvider.
        /// </summary>
        protected Func<ApiContextOptions> ApiContextOptionsProvider { get; set; }

        /// <summary>
        /// Gets or sets provider of UrlOptions.
        /// </summary>
        protected Func<UrlOptions> UrlOptionsProvider { get; set; }

        /// <summary>
        /// Add api context options for iDoklad API.
        /// </summary>
        /// <param name="options">ApiContextOptions.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public DokladApiBuilder AddApiContextOptions(Action<ApiContextOptions> options)
        {
            ApiContextOptionsProvider = () =>
            {
                var apiContextOptions = new ApiContextOptions();
                options(apiContextOptions);
                return apiContextOptions;
            };

            return this;
        }

        /// <summary>
        /// Add custom URLs for iDoklad API.
        /// </summary>
        /// <param name="apiUrl">URL of iDoklad API.</param>
        /// <param name="identityServerUrl">URL of token endpoint of Identity server.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public DokladApiBuilder AddCustomApiUrls(string apiUrl, string identityServerUrl)
        {
            return AddCustomApiUrls(options =>
            {
                options.ApiUrl = apiUrl;
                options.IdentityServerTokenUrl = identityServerUrl;
            });
        }

        /// <summary>
        /// Add ClientCredentialsAuthentication for iDoklad API.
        /// </summary>
        /// <param name="clientId">ClientId.</param>
        /// <param name="clientSecret">ClientSecret.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public DokladApiBuilder AddClientCredentialsAuthentication(string clientId, string clientSecret)
        {
            return AddAuthentication(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.GrantType = GrantType.ClientCredentials;
            });
        }

        /// <summary>
        /// Add AuthorizationCodeAuthentication for iDoklad API.
        /// </summary>
        /// <param name="clientId">ClientId.</param>
        /// <param name="clientSecret">ClientSecret.</param>
        /// <param name="authorizationCode">AuthorizationCode.</param>
        /// <param name="redirectUri">RedirectUri.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public DokladApiBuilder AddAuthorizationCodeAuthentication(string clientId, string clientSecret, string authorizationCode, string redirectUri)
        {
            return AddAuthentication(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.AuthorizationCode = authorizationCode;
                options.RedirectUri = redirectUri;
                options.GrantType = GrantType.AuthorizationCode;
            });
        }

        /// <summary>
        /// Add AuthorizationCodeAuthentication for iDoklad API.
        /// </summary>
        /// <param name="clientId">ClientId.</param>
        /// <param name="clientSecret">ClientSecret.</param>
        /// <param name="refreshToken">RefreshToken.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public DokladApiBuilder AddAuthorizationCodeAuthentication(string clientId, string clientSecret, string refreshToken)
        {
            return AddAuthentication(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.RefreshToken = refreshToken;
                options.GrantType = GrantType.AuthorizationCode;
            });
        }

        /// <summary>
        /// Add PinAuthentication for iDoklad API.
        /// </summary>
        /// <param name="clientId">ClientId.</param>
        /// <param name="clientSecret">ClientSecret.</param>
        /// <param name="pin">Pin.</param>
        /// <param name="refreshToken">RefreshToken.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public DokladApiBuilder AddPinAuthentication(string clientId, string clientSecret, string pin = null, string refreshToken = null)
        {
            return AddAuthentication(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.Pin = pin;
                options.RefreshToken = refreshToken;
                options.GrantType = GrantType.Pin;
            });
        }

        /// <summary>
        /// Build iDoklad API.
        /// </summary>
        /// <returns>Instance of DokladApi.</returns>
        public virtual DokladApi Build()
        {
            var configuration = GetConfiguration();
            var auth = GetAuthentication();
            auth.Configuration = configuration;
            var context = GetApicontext(auth, configuration);

            return new DokladApi(context);
        }

        /// <summary>
        /// Add authentication for iDoklad API.
        /// </summary>
        /// <param name="options">AuthenticationOptions.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        protected DokladApiBuilder AddAuthentication(Action<AuthenticationOptions> options)
        {
            AuthenticationOptionsProvider = () =>
            {
                var authenticationOptions = new AuthenticationOptions();
                options(authenticationOptions);
                return authenticationOptions;
            };

            return this;
        }

        /// <summary>
        /// Add custom URLs for iDoklad API.
        /// </summary>
        /// <param name="options">UrlOptions.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        protected DokladApiBuilder AddCustomApiUrls(Action<UrlOptions> options)
        {
            UrlOptionsProvider = () =>
            {
                var urlOptions = new UrlOptions();
                options(urlOptions);
                return urlOptions;
            };

            return this;
        }

        /// <summary>
        /// Get specific authentication.
        /// </summary>
        /// <returns>Instance of IAuthentication.</returns>
        /// <exception cref="InvalidOperationException">Throws when GrantType is not supported.</exception>
        /// <exception cref="IdokladSdkException">Throws when AuthenticationOptions were not set yet.</exception>
        protected virtual IAuthentication GetAuthentication()
        {
            if (AuthenticationOptionsProvider == null)
            {
                throw new InvalidOperationException("Missing authentication.");
            }

            var authOptions = AuthenticationOptionsProvider();

            switch (authOptions.GrantType)
            {
                case GrantType.AuthorizationCode:
                    return authOptions.UseRefreshToken
                        ? new AuthorizationCodeAuthentication(authOptions.ClientId, authOptions.ClientSecret, authOptions.RefreshToken)
                        : new AuthorizationCodeAuthentication(authOptions.ClientId, authOptions.ClientSecret, authOptions.AuthorizationCode, authOptions.RedirectUri);
                case GrantType.ClientCredentials:
                    return new ClientCredentialsAuthentication(authOptions.ClientId, authOptions.ClientSecret);
                case GrantType.Pin:
                    return new PinAuthentication(authOptions.ClientId, authOptions.ClientSecret, authOptions.Pin, authOptions.RefreshToken);
                default:
                    throw new IdokladSdkException("Missing authentication grant type.");
            }
        }

        /// <summary>
        /// Create configuration for iDoklad API.
        /// </summary>
        /// <returns>Instance of Dokladconfiguration.</returns>
        protected DokladConfiguration GetConfiguration()
        {
            var urlOptions = UrlOptionsProvider?.Invoke();
            if (urlOptions == null || (string.IsNullOrWhiteSpace(urlOptions.ApiUrl) && string.IsNullOrWhiteSpace(urlOptions.IdentityServerTokenUrl)))
            {
                return new DokladConfiguration();
            }

            return new DokladConfiguration(urlOptions.ApiUrl, urlOptions.IdentityServerTokenUrl);
        }

        private ApiContext GetApicontext(IAuthentication auth, DokladConfiguration configuration)
        {
            var context = new ApiContext(_appName, _appVersion, auth, configuration);

            if (ApiContextOptionsProvider != null)
            {
                var resultHandlers = ApiContextOptionsProvider();
                context.ApiResultHandler = resultHandlers.ApiResultHandler;
                context.ApiBatchResultHandler = resultHandlers.ApiBatchResultHandler;
                context.SetLanguage(resultHandlers.Language ?? Language.En);
            }

            return context;
        }
    }
}
