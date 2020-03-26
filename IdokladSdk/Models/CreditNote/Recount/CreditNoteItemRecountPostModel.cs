using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteItemRecountPostModel.
    /// </summary>
    public class CreditNoteItemRecountPostModel : ItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        [Range(0.0, 99.99)]
        [Required]
        public decimal DiscountPercentage { get; set; }
    }
}
