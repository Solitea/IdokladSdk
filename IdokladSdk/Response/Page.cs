using System.Collections.Generic;

namespace IdokladSdk.Response
{
    /// <summary>
    /// Page result.
    /// </summary>
    /// <typeparam name="TApiResult">Type of API result.</typeparam>
    public class Page<TApiResult>
    {
        /// <summary>
        /// Gets or sets list of entities on this page.
        /// </summary>
        public IEnumerable<TApiResult> Items { get; set; }

        /// <summary>
        /// Gets or sets total number of entries.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets total number of pages.
        /// </summary>
        public int TotalPages { get; set; }
    }
}
