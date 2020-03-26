using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptItem Model for Get endpoints.
    /// </summary>
    public class SalesReceiptItemGetModel : SalesReceiptItemListGetModel
    {
        /// <summary>
        /// Gets or sets PriceListItem.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
