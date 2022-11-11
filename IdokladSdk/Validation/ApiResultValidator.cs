using System;
using System.Net;
using System.Net.Http;
using IdokladSdk.Exceptions;

namespace IdokladSdk.Validation
{
    /// <summary>
    /// API result validator.
    /// </summary>
    public static class ApiResultValidator
    {
        public static void ValidateResponse(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response), "Response cannot be null.");
            }

            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                throw new IdokladUnavailableException(response);
            }
        }
    }
}
