using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedReceipt.Patch
{
    /// <summary>
    /// ReceivedReceiptItemPatchModel.
    /// </summary>
    public class ReceivedReceiptItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets the item amount.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the custom VAT.
        /// </summary>
        public NullableProperty<decimal> CustomVat { get; set; }

        /// <summary>
        /// Gets or sets the entity's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase? PriceType { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the VAT classification code.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
