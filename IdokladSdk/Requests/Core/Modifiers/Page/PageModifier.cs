using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Requests.Core.Interfaces;

namespace IdokladSdk.Requests.Core.Modifiers.Page
{
    /// <summary>
    /// Query string page modifier.
    /// </summary>
    public class PageModifier : IQueryStringModifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageModifier"/> class.
        /// </summary>
        public PageModifier()
        {
            Page = Constants.DefaultPage;
            PageSize = Constants.DefaultPageSize;
        }

        /// <summary>
        /// Gets or sets number of a page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            return new Dictionary<string, string>
            {
                { "page",  Page.ToString(CultureInfo.InvariantCulture) },
                { "pageSize", PageSize.ToString(CultureInfo.InvariantCulture) }
            };
        }
    }
}
