using System.Net.Http;

namespace IdokladSdk.Exceptions
{
    /// <summary>
    /// IdokladAuthorizationException.
    /// </summary>
    public class IdokladAuthorizationException : IdokladBaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladAuthorizationException"/> class.
        /// </summary>
        /// <param name="response">RestResponse.</param>
        public IdokladAuthorizationException(HttpResponseMessage response)
            : base("User is not authorized")
        {
            Response = response;
        }

        /// <summary>
        /// Gets response.
        /// </summary>
        public HttpResponseMessage Response { get; private set; }
    }
}
