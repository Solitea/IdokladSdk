using System.Net.Http;
using IdokladSdk.Authentication;

namespace IdokladSdk
{
    /// <summary>
    /// ApiContext configuration.
    /// </summary>
    public class ApiContextConfiguration
    {
        /// <summary>
        /// Gets or sets HttpClient for Doklad API.
        /// </summary>
        public HttpClient HttpClient { get; set; }

        /// <summary>
        /// Gets or sets your application name.
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Gets or sets your application version.
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Gets or sets authentication configuration.
        /// </summary>
        public IAuthentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets custom configuration for iDoklad API.
        /// </summary>
        public DokladConfiguration Configuration { get; set; }
    }
}
