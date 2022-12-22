using System;
using System.Net.Http;

namespace IdokladSdk.Exceptions
{
    /// <summary>
    /// IdokladUnavailableException.
    /// </summary>
    public class IdokladUnavailableException : IdokladBaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladUnavailableException"/> class.
        /// </summary>
        public IdokladUnavailableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladUnavailableException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public IdokladUnavailableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladUnavailableException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public IdokladUnavailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladUnavailableException"/> class.
        /// </summary>
        /// <param name="response">RestResponse.</param>
        public IdokladUnavailableException(HttpResponseMessage response)
            : base("iDoklad is unavailable.")
        {
            Response = response;
        }

        /// <summary>
        /// Gets response.
        /// </summary>
        public HttpResponseMessage Response { get; private set; }
    }
}
