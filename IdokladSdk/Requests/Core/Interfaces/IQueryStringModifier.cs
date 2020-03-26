using System.Collections.Generic;

namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for query string modifiers.
    /// </summary>
    public interface IQueryStringModifier
    {
        /// <summary>
        /// Get all query parameters.
        /// </summary>
        /// <returns>Dictionary of all query parameters.</returns>
        Dictionary<string, string> GetQueryParameters();
    }
}
