﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Authentication.Extensions;
using IdokladSdk.Enums;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk
{
    /// <summary>
    /// API context.
    /// </summary>
    public class ApiContext
    {
        private readonly IAuthentication _authentication;
        private Tokenizer _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext"/> class.
        /// </summary>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        /// <param name="authentication">Authentication configuration.</param>
        [Obsolete("Use DokladApiBuilder instead.")]
        public ApiContext(string appName, string appVersion, IAuthentication authentication)
            : this(new ApiContextConfiguration
            {
                AppName = appName,
                AppVersion = appVersion,
                Authentication = authentication,
                Configuration = new DokladConfiguration(),
                ApiHttpClient = new HttpClient(),
                IdentityHttpClient = new HttpClient()
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext"/> class.
        /// </summary>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        /// <param name="authentication">Authentication configuration.</param>
        /// <param name="configuration">Custom configuration for iDoklad API.</param>
        [Obsolete("Use DokladApiBuilder instead.")]
        public ApiContext(string appName, string appVersion, IAuthentication authentication, DokladConfiguration configuration)
            : this(new ApiContextConfiguration
            {
                AppName = appName,
                AppVersion = appVersion,
                Authentication = authentication,
                Configuration = configuration,
                ApiHttpClient = new HttpClient(),
                IdentityHttpClient = new HttpClient()
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext"/> class.
        /// </summary>
        /// <param name="httpClient">HttpClient.</param>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        /// <param name="authentication">Authentication configuration.</param>
        /// <param name="configuration">Custom configuration for iDoklad API.</param>
        public ApiContext(HttpClient httpClient, string appName, string appVersion, IAuthentication authentication, DokladConfiguration configuration)
        {
            if (httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient), "HttpClient cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(appName))
            {
                throw new ArgumentException("AppName has to be supplied.", nameof(appName));
            }

            if (string.IsNullOrWhiteSpace(appVersion))
            {
                throw new ArgumentException("AppVersion has to be supplied.", nameof(appVersion));
            }

            ApiRestClient = new RestClient(httpClient);
            AppName = appName;
            AppVersion = appVersion;
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication), "Authentication cannot be null.");
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
            _authentication.Configuration = configuration;
        }

        internal ApiContext(ApiContextConfiguration apiContextConfiguration)
        {
            ValidateApiContextConfiguration(apiContextConfiguration);

            ApiRestClient = new RestClient(apiContextConfiguration.ApiHttpClient);
            IdentityRestClient = new RestClient(apiContextConfiguration.IdentityHttpClient);
            AppName = apiContextConfiguration.AppName;
            AppVersion = apiContextConfiguration.AppVersion;
            Configuration = apiContextConfiguration.Configuration;

            _authentication = apiContextConfiguration.Authentication;
            _authentication.Configuration = apiContextConfiguration.Configuration;
        }

        /// <summary>
        /// Gets refresh token before expiration limit (in seconds).
        /// </summary>
        public static int RefreshTokenLimit => 600;

        /// <summary>
        /// Gets your application name.
        /// </summary>
        public string AppName { get; }

        /// <summary>
        /// Gets your application version.
        /// </summary>
        public string AppVersion { get; }

        /// <summary>
        /// Gets configuration of API context.
        /// </summary>
        public DokladConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets a method for handling unsuccessful API result.
        /// </summary>
        public Action<ApiResult> ApiResultHandler { get; set; } = null;

        /// <summary>
        /// Gets or sets a method for handling unsuccessful API Batch result.
        /// </summary>
        public Action<ApiBatchResult> ApiBatchResultHandler { get; set; } = null;

        /// <summary>
        /// Gets additional headers sent with each API request.
        /// </summary>
        public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets RestClient for ApiRestClient.
        /// </summary>
        public RestClient ApiRestClient { get; }

        /// <summary>
        /// Gets RestClient for IdentityRestClient.
        /// </summary>
        public RestClient IdentityRestClient { get; }

        /// <summary>
        /// Gets claims from token.
        /// </summary>
        public TokenClaims TokenClaims { get; private set; }

        /// <summary>
        /// Access token.
        /// </summary>
        /// <returns>Tokenizer.</returns>
        public Tokenizer GetToken()
        {
            return GetTokenAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns existing Tokenizer and if necessary, refreshes it.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>up-to-date Tokenizer.</returns>
        public async Task<Tokenizer> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            if (_authentication.UseRefreshToken)
            {
                _token = await _authentication.RefreshAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                _authentication.UseRefreshToken = false;
            }

            if (_token is null)
            {
                _token = await _authentication.GetTokenAsync(cancellationToken).ConfigureAwait(false);
            }

            if (_token.ShouldBeRefreshedNow(RefreshTokenLimit))
            {
                _token = await _authentication.RefreshAccessTokenAsync(cancellationToken).ConfigureAwait(false);
            }

            TokenClaims = new TokenClaims(_token.Claims);

            return _token;
        }

        /// <summary>
        /// Sets AcceptedLanguage header to one of supported language.
        /// </summary>
        /// <param name="language">Language id.</param>
        public void SetLanguage(Language language)
        {
            var locale = "en-US";

            if (language == Language.Cz)
            {
                locale = "cs-CZ";
            }
            else if (language == Language.Sk)
            {
                locale = "sk-SK";
            }
            else if (language == Language.De)
            {
                locale = "de-DE";
            }

            Headers["Accept-Language"] = locale;
        }

        private void ValidateApiContextConfiguration(ApiContextConfiguration contextConfiguration)
        {
            if (contextConfiguration is null)
            {
                throw new ArgumentNullException(nameof(contextConfiguration), "Missing configuration for ApiContext.");
            }

            if (contextConfiguration.ApiHttpClient is null)
            {
                throw new ArgumentNullException(nameof(contextConfiguration.ApiHttpClient), "ApiHttpClient cannot be null.");
            }

            if (contextConfiguration.IdentityHttpClient is null)
            {
                throw new ArgumentNullException(nameof(contextConfiguration.IdentityHttpClient), "IdentityHttpClient cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(contextConfiguration.AppName))
            {
                throw new ArgumentException("AppName has to be supplied.", nameof(contextConfiguration.AppName));
            }

            if (string.IsNullOrWhiteSpace(contextConfiguration.AppVersion))
            {
                throw new ArgumentException("AppVersion has to be supplied.", nameof(contextConfiguration.AppVersion));
            }

            if (contextConfiguration.Authentication is null)
            {
                throw new ArgumentNullException(nameof(contextConfiguration.Authentication), "Authentication cannot be null.");
            }

            if (contextConfiguration.Configuration is null)
            {
                throw new ArgumentNullException(nameof(contextConfiguration.Configuration), "Configuration cannot be null.");
            }
        }
    }
}
