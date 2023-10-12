using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ProformaInvoice.Get
{
    /// <summary>
    /// ProformaInvoiceItemFromSalesOrderGetModel.
    /// </summary>
    public class ProformaInvoiceItemFromSalesOrderGetModel
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
        /// Gets or sets a value indicating whether is the item a tax movement indication.
        /// </summary>
        [Required]
        public bool IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets Item type.
        /// </summary>
        public ProformaInvoiceItemType ItemType { get; set; }

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
        /// Gets or sets vAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }

        /// <summary>
        /// Gets or sets id členení DPH.
        /// </summary>
        [NullableForeignKey]
        public int? VatCodeId { get; set; }
    }
}
