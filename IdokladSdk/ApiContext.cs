using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Enums;
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
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        /// <param name="authentication">Authentication configuration.</param>
        public ApiContext(string appName, string appVersion, IAuthentication authentication)
            : this(appName, appVersion, authentication, new DokladConfiguration())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext"/> class.
        /// </summary>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        /// <param name="authentication">Authentication configuration.</param>
        /// <param name="configuration">Custom configuration for iDoklad API.</param>
        public ApiContext(string appName, string appVersion, IAuthentication authentication, DokladConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(appName))
            {
                throw new ArgumentException("AppName has to be supplied.", nameof(appName));
            }

            if (string.IsNullOrWhiteSpace(appVersion))
            {
                throw new ArgumentException("AppVersion has to be supplied.", nameof(appVersion));
            }

            AppName = appName;
            AppVersion = appVersion;
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication), "Authentication cannot be null.");
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
            _authentication.Configuration = configuration;
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
        /// Access token.
        /// </summary>
        /// <returns>Tokenizer.</returns>
        public Tokenizer GetToken()
        {
            if (_authentication.UseRefreshToken)
            {
                _token = _authentication.RefreshAccessToken();
                _authentication.UseRefreshToken = false;
            }

            if (_token is null)
            {
                _token = _authentication.GetToken();
            }

            if (_token.ShouldBeRefreshedNow(RefreshTokenLimit))
            {
                _token = _authentication.RefreshAccessToken();
            }

            return _token;
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
    }
}
