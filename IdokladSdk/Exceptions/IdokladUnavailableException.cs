using System;
using RestSharp;

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
        public IdokladUnavailableException(IRestResponse response)
            : base("iDoklad is unavailable.")
        {
            Response = response;
        }

        /// <summary>
        /// Gets response.
        /// </summary>
        public IRestResponse Response { get; private set; }
    }
}
