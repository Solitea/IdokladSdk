using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteItemPostModel.
    /// </summary>
    public class CreditNoteItemPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Required]
        [DecimalRange]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item code.
        /// </summary>
        [StringLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets discount name.
        /// </summary>
        [StringLength(200)]
        public string DiscountName { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        [Range(0.0, 99.99)]
        [Required]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is a tax movement.
        /// </summary>
        [Required]
        public bool IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item id.
        /// </summary>
        [NullableForeignKey]
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        [NullableForeignKey]
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }

        /// <summary>
        /// Gets or sets vat rate in percent.
        /// </summary>
        public decimal? VatRate { get; set; }
    }
}
