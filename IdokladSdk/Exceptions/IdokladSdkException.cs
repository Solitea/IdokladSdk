using System;
using System.Linq;
using IdokladSdk.Response;

namespace IdokladSdk.Exceptions
{
    /// <summary>
    /// IdokladSdkException.
    /// </summary>
    public class IdokladSdkException : IdokladBaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladSdkException" /> class.
        /// </summary>
        /// <param name="apiBatchResult">API batch result.</param>
        public IdokladSdkException(ApiBatchResult apiBatchResult)
            : base(GetMessages(apiBatchResult))
        {
            ApiBatchResult = apiBatchResult ?? throw new ArgumentNullException(nameof(apiBatchResult));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladSdkException" /> class.
        /// </summary>
        /// <param name="apiResult">API result.</param>
        public IdokladSdkException(ApiResult apiResult)
            : base(apiResult?.Message)
        {
            ApiResult = apiResult ?? throw new ArgumentNullException(nameof(apiResult));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladSdkException" /> class.
        /// </summary>
        public IdokladSdkException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladSdkException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public IdokladSdkException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladSdkException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public IdokladSdkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets or sets API batch result.
        /// </summary>
        public ApiBatchResult ApiBatchResult { get; set; }

        /// <summary>
        /// Gets or sets API result.
        /// </summary>
        public ApiResult ApiResult { get; set; }

        private static string GetMessages(ApiBatchResult apiBatchResult)
        {
            var messages = apiBatchResult.GetBaseResults().Select(r => r.Message);

            return string.Join("\r\n", messages);
        }
    }
}
