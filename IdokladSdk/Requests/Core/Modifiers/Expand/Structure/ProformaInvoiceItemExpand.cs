using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ProformaInvoiceItemExpand.
    /// </summary>
    public class ProformaInvoiceItemExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemExpand PriceListItem { get; set; }
    }
}
