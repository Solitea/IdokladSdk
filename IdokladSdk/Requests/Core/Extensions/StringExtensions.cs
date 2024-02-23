using System;
using System.Diagnostics;
using System.Text;

namespace IdokladSdk.Requests.Core.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified value is not null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c>true</c> if the specified value is null or empty; otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Covert to base64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The value in base64 format.</returns>
        public static string ToBase64(this string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                var valueBytes = Encoding.UTF8.GetBytes(value);
                return Convert.ToBase64String(valueBytes);
            }

            return value;
        }
    }
}
