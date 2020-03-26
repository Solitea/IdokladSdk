using System.Net;
using IdokladSdk.Enums;

namespace IdokladSdk.Response
{
    /// <summary>
    /// API result.
    /// </summary>
    public abstract class ApiResult
    {
        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        public DokladErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether request was successful.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets HTTP status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
