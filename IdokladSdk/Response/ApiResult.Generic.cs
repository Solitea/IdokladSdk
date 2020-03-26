using IdokladSdk.Exceptions;
using IdokladSdk.Serialization;
using Newtonsoft.Json;

namespace IdokladSdk.Response
{
    /// <summary>
    /// API result.
    /// </summary>
    /// <typeparam name="TData">Return data from endpoints.</typeparam>
    public class ApiResult<TData> : ApiResult
    {
        /// <summary>
        /// Gets or sets data.
        /// </summary>
        [JsonConverter(typeof(ApiResultDataJsonConverter))]
        public TData Data { get; set; }

        /// <summary>
        /// Checks API response and returns data if operation was successful; otherwise throws an exception.
        /// </summary>
        /// <returns>Data from API.</returns>
        public TData CheckResult()
        {
            if (!IsSuccess)
            {
                throw new IdokladSdkException(this);
            }

            return Data;
        }
    }
}
