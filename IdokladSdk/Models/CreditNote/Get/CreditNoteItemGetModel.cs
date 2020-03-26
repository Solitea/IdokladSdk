using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteItemGetModel.
    /// </summary>
    public class CreditNoteItemGetModel : CreditNoteItemListGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }
    }
}
