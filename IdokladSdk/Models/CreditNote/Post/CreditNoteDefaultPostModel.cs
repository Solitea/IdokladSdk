using IdokladSdk.Enums;

namespace IdokladSdk.Models.CreditNote.Post
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
