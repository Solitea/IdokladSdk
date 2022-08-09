using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
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

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public IssuedInvoiceItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType? PriceType { get; set; }
    }
}
