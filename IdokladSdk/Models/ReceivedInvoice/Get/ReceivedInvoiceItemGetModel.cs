using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceItemGetModel.
    /// </summary>
    public class ReceivedInvoiceItemGetModel : ReceivedInvoiceItemListGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
