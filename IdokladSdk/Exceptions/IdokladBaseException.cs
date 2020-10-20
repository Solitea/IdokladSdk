using System;

namespace IdokladSdk.Exceptions
{
    /// <summary>
    /// IdokladBaseException.
    /// </summary>
    public abstract class IdokladBaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladBaseException"/> class.
        /// </summary>
        public IdokladBaseException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladBaseException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public IdokladBaseException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladBaseException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public IdokladBaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
