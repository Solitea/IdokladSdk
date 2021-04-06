using System;
using System.Globalization;
using System.Text.RegularExpressions;
using IdokladSdk.Enums;
using Newtonsoft.Json;

namespace IdokladSdk.Authentication.Models
{
    /// <summary>
    /// AuthenticationError.
    /// </summary>
    public class AuthenticationError
    {
        /// <summary>
        /// Gets or sets authentication error.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets authentication error description.
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets authentication error code.
        /// </summary>
        public AuthenticationErrorCode? ErrorCode => GetErrorCode();

        private AuthenticationErrorCode? GetErrorCode()
        {
            if (string.IsNullOrWhiteSpace(ErrorDescription))
            {
                return null;
            }

            return ParseErrorCode();
        }

        private AuthenticationErrorCode? ParseErrorCode()
        {
            var errorCode = Regex.Match(ErrorDescription, @"^AuthErrorCode?\((\d+)\)").Groups[1].Value;

            if (string.IsNullOrWhiteSpace(errorCode))
            {
                return null;
            }

            return ConvertToErrorCode(errorCode);
        }

        private AuthenticationErrorCode? ConvertToErrorCode(string text)
        {
            var errorCode = Convert.ToInt32(text, CultureInfo.InvariantCulture);
            return Enum.IsDefined(typeof(AuthenticationErrorCode), errorCode)
                ? (AuthenticationErrorCode?)errorCode
                : null;
        }
    }
}
