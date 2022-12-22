using System;
using System.Net.Http;
using IdokladSdk.Authentication;
using IdokladSdk.Builders.Options;
using IdokladSdk.Enums;
using IdokladSdk.Exceptions;

namespace IdokladSdk.Builders
{
    /// <summary>
    /// Builder for iDoklad API.
    /// </summary>
    public class DokladApiBuilder : BaseDokladApiBuilder<DokladApiBuilder, DokladApi>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DokladApiBuilder"/> class.
        /// </summary>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        public DokladApiBuilder(string appName, string appVersion)
            : base(appName, appVersion)
        {
        }

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
        public override DokladApi Build()
        {
            var configuration = GetConfiguration();
            var auth = GetAuthentication();
            auth.Configuration = configuration;
            var context = GetApicontext(auth, configuration);

            return new DokladApi(context);
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

        private ApiContext GetApicontext(IAuthentication auth, DokladConfiguration configuration)
        {
            if (HttpClient is null)
            {
                throw new IdokladSdkException($"Missing HttpClient instance. Use method {nameof(AddHttpClient)} to add new instance.");
            }

            var contextConfiguration = new ApiContextConfiguration
            {
                AppName = AppName,
                AppVersion = AppVersion,
                HttpClient = HttpClient,
                Authentication = auth,
                Configuration = configuration
            };

            var context = new ApiContext(contextConfiguration);

            if (ApiContextOptionsProvider != null)
            {
                var resultHandlers = ApiContextOptionsProvider();
                context.ApiResultHandler = resultHandlers.ApiResultHandler;
                context.ApiBatchResultHandler = resultHandlers.ApiBatchResultHandler;
                context.SetLanguage(resultHandlers.Language ?? Language.Cz);
            }

            return context;
        }
    }
}
