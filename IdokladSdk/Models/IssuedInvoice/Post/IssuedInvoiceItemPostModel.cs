using System.ComponentModel.DataAnnotations;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceItemPostModel.
    /// </summary>
    public class IssuedInvoiceItemPostModel : ValidatableModel
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
        /// Gets or sets invoice proforma id.
        /// </summary>
        [NullableForeignKey]
        public int? InvoiceProformaId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the item a tax movement indication.
        /// </summary>
        [Required]
        public bool IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public PostIssuedInvoiceItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets pricelist item id.
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
        /// Gets or sets id členení DPH.
        /// </summary>
        [NullableForeignKey]
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
