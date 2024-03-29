﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Enums;
using IdokladSdk.Exceptions;
using IdokladSdk.Response;

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
        /// <param name="apiContextConfiguration">Configuration fo ApiContext.</param>
        protected internal ApiContext(ApiContextConfiguration apiContextConfiguration)
        {
            ValidateApiContextConfiguration(apiContextConfiguration);

            HttpClient = apiContextConfiguration.HttpClient;
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
        /// Gets HttpClient for API.
        /// </summary>
        public HttpClient HttpClient { get; }

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
        /// Gets claims from token.
        /// </summary>
        public TokenClaims TokenClaims { get; private set; }

        /// <summary>
        /// Returns existing Tokenizer and if necessary, refreshes it.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>up-to-date Tokenizer.</returns>
        public async Task<Tokenizer> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            ValidateHttpClient(HttpClient);

            if (_authentication.UseRefreshToken)
            {
                _token = await _authentication.RefreshAccessTokenAsync(HttpClient, cancellationToken).ConfigureAwait(false);
                _authentication.UseRefreshToken = false;
            }

            if (_token is null)
            {
                _token = await _authentication.GetTokenAsync(HttpClient, cancellationToken).ConfigureAwait(false);
            }

            if (_token.ShouldBeRefreshedNow(RefreshTokenLimit))
            {
                _token = await _authentication.RefreshAccessTokenAsync(HttpClient, cancellationToken).ConfigureAwait(false);
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

            ValidateHttpClient(contextConfiguration.HttpClient);

            if (string.IsNullOrWhiteSpace(contextConfiguration.AppName))
            {
                throw new ArgumentNullException(nameof(contextConfiguration.AppName), "AppName has to be supplied.");
            }

            if (string.IsNullOrWhiteSpace(contextConfiguration.AppVersion))
            {
                throw new ArgumentNullException(nameof(contextConfiguration.AppVersion), "AppVersion has to be supplied.");
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

        private void ValidateHttpClient(HttpClient httpClient)
        {
            if (httpClient is null)
            {
                throw new ArgumentNullException("HttpClient", "HttpClient cannot be null.");
            }

            if (httpClient.BaseAddress != null)
            {
                throw new IdokladSdkException("HttpClient cannot have BaseAddress set.");
            }
        }
    }
}
