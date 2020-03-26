using System;
using Newtonsoft.Json;

namespace IdokladSdk.Authentication
{
    /// <summary>
    /// Informations about token.
    /// </summary>
    public class Tokenizer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tokenizer"/> class.
        /// </summary>
        public Tokenizer()
        {
            Issued = DateTime.Now;
        }

        /// <summary>
        /// Gets grant type.
        /// </summary>
        public GrantType GrantType { get; internal set; }

        /// <summary>
        /// Gets client id.
        /// </summary>
        public string ClientId { get; internal set; }

        /// <summary>
        /// Gets client secret.
        /// </summary>
        public string ClientSecret { get; internal set; }

        /// <summary>
        /// Gets redirect URI.
        /// </summary>
        public string RedirectUri { get; internal set; }

        /// <summary>
        /// Gets access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; internal set; }

        /// <summary>
        /// Gets refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; internal set; }

        /// <summary>
        /// Gets count of seconds after which the access token will expire.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; internal set; }

        /// <summary>
        /// Gets date and time when the token was issued.
        /// </summary>
        public DateTime Issued { get; }

        /// <summary>
        /// Determines whether the access token is valid.
        /// </summary>
        /// <param name="date">Current date and time.</param>
        /// <returns><c>true</c> if the access token is valid, otherwise <c>false</c>.</returns>
        public bool IsValid(DateTime date)
        {
            return date < Issued.AddSeconds(ExpiresIn);
        }

        /// <summary>
        /// Determines whether the access token needs to be refreshed.
        /// </summary>
        /// <param name="limitInSeconds">Limit in seconds.</param>
        /// <returns><c>true</c> if GranType is different than Client credentials and access token is valid, otherwise <c>false</c>.</returns>
        public bool ShouldBeRefreshedNow(int limitInSeconds)
        {
            return GrantType != GrantType.ClientCredentials && !IsValid(DateTime.Now.AddSeconds(limitInSeconds));
        }
    }
}
