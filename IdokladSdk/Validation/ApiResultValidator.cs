using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using IdokladSdk.Exceptions;
using RestSharp;

namespace IdokladSdk.Validation
{
    /// <summary>
    /// API result validator.
    /// </summary>
    public static class ApiResultValidator
    {
        /// <summary>
        /// Validate API response.
        /// </summary>
        /// <typeparam name="T">Result type.</typeparam>
        /// <param name="response">Response from RestSharp.</param>
        /// <param name="handler">Custom API result handler.</param>
        public static void ValidateResponse<T>(IRestResponse<T> response, Action<T> handler)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response), "Response cannot be null.");
            }

            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                throw new IdokladUnavailableException(response);
            }

            if (response.ErrorException != null)
            {
                throw new ValidationException($"Response is not valid.", response.ErrorException);
            }

            handler?.Invoke(response.Data);
        }
    }
}
