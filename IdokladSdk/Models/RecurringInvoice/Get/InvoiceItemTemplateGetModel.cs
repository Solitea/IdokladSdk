using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceItemTemplateGetModel.
    /// </summary>
    public class InvoiceItemTemplateGetModel : InvoiceItemTemplateListGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
