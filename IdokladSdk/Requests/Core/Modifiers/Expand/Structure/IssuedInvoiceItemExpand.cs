using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// IssuedInvoiceItemExpand.
    /// </summary>
    public class IssuedInvoiceItemExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets the associated price list item.
        /// </summary>
        public PriceListItemExpand PriceListItem { get; set; }
    }
}
