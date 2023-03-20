using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrderItem Model for Post endpoints.
    /// </summary>
    public class SalesOrderItemPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Required]
        [DecimalRange]
        public decimal Amount { get; set; }

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
        /// Gets or sets vAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }

        /// <summary>
        /// Gets or sets vat code id.
        /// </summary>
        [NullableForeignKey]
        public int? VatCodeId { get; set; }
    }
}
