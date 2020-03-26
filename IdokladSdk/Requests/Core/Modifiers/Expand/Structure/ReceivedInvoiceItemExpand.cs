using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ReceivedInvoiceItemExpand.
    /// </summary>
    public class ReceivedInvoiceItemExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemExpand PriceListItem { get; set; }
    }
}
