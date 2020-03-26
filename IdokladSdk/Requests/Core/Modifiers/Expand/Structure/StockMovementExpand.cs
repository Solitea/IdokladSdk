using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// StockMovementExpand.
    /// </summary>
    public class StockMovementExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets priceListItem.
        /// </summary>
        public PriceListItemExpand PriceListItem { get; set; }
    }
}
