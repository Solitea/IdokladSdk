using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptItemModel for Post enpoints.
    /// </summary>
    public class SalesReceiptItemPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        [Required]
        [DecimalRange]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets name.
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
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
