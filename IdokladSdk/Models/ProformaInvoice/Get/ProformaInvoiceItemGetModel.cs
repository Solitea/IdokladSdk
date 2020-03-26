using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceItemGetModel.
    /// </summary>
    public class ProformaInvoiceItemGetModel : ProformaInvoiceItemListGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
