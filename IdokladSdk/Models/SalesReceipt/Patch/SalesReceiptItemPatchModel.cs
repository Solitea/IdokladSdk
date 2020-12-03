using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// PathModel for SalesReceiptItem.
    /// </summary>
    public class SalesReceiptItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        public decimal? Amount { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase? PriceType { get; set; }

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
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
