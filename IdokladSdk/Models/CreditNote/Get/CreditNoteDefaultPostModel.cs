using IdokladSdk.Enums;

namespace IdokladSdk.Models.CreditNote.Get
{
    /// <summary>
    /// CreditNoteDefaultPostModel.
    /// </summary>
    public class CreditNoteDefaultPostModel : CreditNotePostModel
    {
        /// <summary>
        /// Gets or sets discount type.
        /// </summary>
        public DiscountType DiscountType { get; set; }
    }
}
