using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// Issued invoice item.
    /// </summary>
    public class IssuedInvoiceItemGetModel : IssuedInvoiceItemListGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
