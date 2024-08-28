using System;
using System.Net.Http;
using IdokladSdk.Builders.Options;

namespace IdokladSdk.Builders
{
    /// <summary>
    /// Base builder for iDoklad API.
    /// </summary>
    /// <typeparam name="TBuilder">Builder.</typeparam>
    /// <typeparam name="TApi">Api.</typeparam>
    public abstract class BaseDokladApiBuilder<TBuilder, TApi>
        where TBuilder : BaseDokladApiBuilder<TBuilder, TApi>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDokladApiBuilder{TBuilder,TApi}"/> class.
        /// </summary>
        /// <param name="appName">Your application name.</param>
        /// <param name="appVersion">Your application version.</param>
        protected BaseDokladApiBuilder(string appName, string appVersion)
        {
            AppName = appName;
            AppVersion = appVersion;
        }

        /// <summary>
        /// Gets application name.
        /// </summary>
        protected string AppName { get; }

        /// <summary>
        /// Gets application version.
        /// </summary>
        protected string AppVersion { get; }

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
        /// Gets or sets HttpClient.
        /// </summary>
        protected HttpClient HttpClient { get; set; }

        /// <summary>
        /// Add HttpClient instance for Doklad API.
        /// </summary>
        /// <param name="httpClient">HttpClient.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        public virtual TBuilder AddHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;

            return this as TBuilder;
        }

        /// <summary>
        /// Build iDoklad API.
        /// </summary>
        /// <returns>Instance of API.</returns>
        public abstract TApi Build();

        /// <summary>
        /// Add authentication for iDoklad API.
        /// </summary>
        /// <param name="options">AuthenticationOptions.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        protected TBuilder AddAuthentication(Action<AuthenticationOptions> options)
        {
            AuthenticationOptionsProvider = () =>
            {
                var authenticationOptions = new AuthenticationOptions();
                options(authenticationOptions);
                return authenticationOptions;
            };

            return this as TBuilder;
        }

        /// <summary>
        /// Add custom URLs for iDoklad API.
        /// </summary>
        /// <param name="options">UrlOptions.</param>
        /// <returns>Current instance of DokladApiBuilder.</returns>
        protected TBuilder AddCustomApiUrls(Action<UrlOptions> options)
        {
            UrlOptionsProvider = () =>
            {
                var urlOptions = new UrlOptions();
                options(urlOptions);
                return urlOptions;
            };

            return this as TBuilder;
        }

        /// <summary>
        /// Create configuration for iDoklad API.
        /// </summary>
        /// <returns>Instance of DokladConfiguration.</returns>
        protected DokladConfiguration GetConfiguration()
        {
            var urlOptions = UrlOptionsProvider?.Invoke();
            if (urlOptions == null || (string.IsNullOrWhiteSpace(urlOptions.ApiUrl) && string.IsNullOrWhiteSpace(urlOptions.IdentityServerUrl)))
            {
                return new DokladConfiguration();
            }

            return new DokladConfiguration(urlOptions.ApiUrl, urlOptions.IdentityServerUrl);
        }
    }
}
