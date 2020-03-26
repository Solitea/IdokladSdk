using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for SalesOrderItem.
    /// </summary>
    public class SalesOrderItemExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets PriceListItem.
        /// </summary>
        public PriceListItemExpand PriceListItem { get; }
    }
}
