using System;
using System.Security.Authentication;
using IdokladSdk.Authentication.Models;

namespace IdokladSdk.Exceptions
{
    /// <summary>
    /// IdokladAuthenticationException.
    /// </summary>
    public class IdokladAuthenticationException : AuthenticationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladAuthenticationException"/> class.
        /// </summary>
        public IdokladAuthenticationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladAuthenticationException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public IdokladAuthenticationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladAuthenticationException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public IdokladAuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladAuthenticationException"/> class.
        /// </summary>
        /// <param name="authenticationError">Authentication error.</param>
        public IdokladAuthenticationException(AuthenticationError authenticationError)
            : base($"Authentication failed: {authenticationError?.Error}")
        {
            AuthenticationError = authenticationError;
        }

        /// <summary>
        /// Gets authentication error.
        /// </summary>
        public AuthenticationError AuthenticationError { get; private set; }
    }
}
