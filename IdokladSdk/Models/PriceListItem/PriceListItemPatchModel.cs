using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.PriceListItem
{
    /// <summary>
    /// PriceListItemPatchModel.
    /// </summary>
    public class PriceListItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets item bar code.
        /// </summary>
        [StringLength(20)]
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets item code.
        /// </summary>
        [StringLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [NullableForeignKey]
        public int? CurrencyId { get; set; }

        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets stock item indicator.
        /// </summary>
        public bool? IsStockItem { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal? Price { get; set; }

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
        /// Gets or sets VAT classification code.
        /// </summary>
        [NullableForeignKey]
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
