using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrderItem Model for Get endpoints.
    /// </summary>
    public class SalesOrderItemGetModel : SalesOrderItemListGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
