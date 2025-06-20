using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        public static async Task<TData> ValidateAndDeserializeResponse<TData>(HttpResponseMessage response, Func<HttpResponseMessage, Task<TData>> deserialize, Action<TData> handler)
        {
            ValidateResponse(response);

            TData data;

            try
            {
                data = await deserialize(response);
            }
            catch (Exception)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new IdokladValidationException($"Response is not valid: {content}");
            }

            handler?.Invoke(data);

            return data;
        }
    }
}
