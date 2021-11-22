using System;
using IdokladSdk.Enums;
using IdokladSdk.Response;

namespace IdokladSdk.Builders.Options
{
    /// <summary>
    /// ApiContextOptions.
    /// </summary>
    public class ApiContextOptions
    {
        /// <summary>
        /// Gets or sets a method for handling unsuccessful API result.
        /// </summary>
        public Action<ApiResult> ApiResultHandler { get; set; } = null;

        /// <summary>
        /// Gets or sets a method for handling unsuccessful API Batch result.
        /// </summary>
        public Action<ApiBatchResult> ApiBatchResultHandler { get; set; } = null;

        /// <summary>
        /// Gets or sets Language.
        /// </summary>
        public Language? Language { get; set; }
    }
}
