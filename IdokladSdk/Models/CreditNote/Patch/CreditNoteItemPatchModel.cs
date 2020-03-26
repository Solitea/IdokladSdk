using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteItemPatchModel.
    /// </summary>
    public class CreditNoteItemPatchModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        public decimal? Amount { get; set; }

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
        public NullableProperty<decimal> DiscountPercentage { get; set; }

        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is a tax movement.
        /// </summary>
        public bool? IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item id.
        /// </summary>
        public NullableProperty<int> PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType? PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets vat code id.
        /// </summary>
        public NullableProperty<int> VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
