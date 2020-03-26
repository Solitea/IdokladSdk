using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for SalesReceiptItem.
    /// </summary>
    public class SalesReceiptItemExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets PriceListItem.
        /// </summary>
        public PriceListItemExpand PriceListItem { get; }
    }
}
