using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.StockMovement
{
    /// <summary>
    /// StockMovementGetModel.
    /// </summary>
    public class StockMovementGetModel : StockMovementListGetModel
    {
        /// <summary>
        /// Gets or sets price list items.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
