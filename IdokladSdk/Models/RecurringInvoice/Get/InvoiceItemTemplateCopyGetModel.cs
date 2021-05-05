using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceItemTemplateCopyGetModel.
    /// </summary>
    public class InvoiceItemTemplateCopyGetModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public RecurringInvoiceItemGetType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item id.
        /// </summary>
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
        /// Gets or sets VAT code id.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
