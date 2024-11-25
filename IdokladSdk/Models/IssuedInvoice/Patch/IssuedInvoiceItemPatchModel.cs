using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceItemPatchModel.
    /// </summary>
    public class IssuedInvoiceItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [DecimalRange]
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
        [NullableRange(0.0, 99.99)]
        public NullableProperty<decimal> DiscountPercentage { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets value indicating, whether the item is a tax movement.
        /// </summary>
        public bool? IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType? PriceType { get; set; }

        /// <summary>
        /// Gets or sets pricelist item id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> PriceListItemId { get; set; }

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
        [NullableForeignKey]
        public NullableProperty<int> VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vat rate type.
        /// </summary>
        [RequiredIfHasValue(nameof(VatRate))]
        public VatRateType? VatRateType { get; set; }

        /// <summary>
        /// Gets or sets vat rate in percent.
        /// </summary>
        public decimal? VatRate { get; set; }
    }
}
