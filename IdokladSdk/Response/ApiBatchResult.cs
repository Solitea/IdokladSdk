using System.Collections.Generic;
using IdokladSdk.Enums;

namespace IdokladSdk.Response
{
    /// <summary>
    /// API batch result.
    /// </summary>
    public abstract class ApiBatchResult
    {
        /// <summary>
        /// Gets batch result type.
        /// </summary>
        public abstract BatchResultType Status { get; }

        /// <summary>
        /// Get Base API results.
        /// </summary>
        /// <returns>Collection of base API results.</returns>
        public abstract IEnumerable<ApiResult> GetBaseResults();
    }
}
