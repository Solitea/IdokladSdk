using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.RecurringInvoice.Get
{
    /// <summary>
    /// InvoiceItemTemplateCopyGetModel.
    /// </summary>
    public class InvoiceItemTemplateCopyGetModel
    {
        /// <summary>
        /// Gets or Sets Item amount.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets Item type.
        /// </summary>
        public RecurringInvoiceItemGetType ItemType { get; set; }

        /// <summary>
        /// Gets or Sets Item name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Pricelist item id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or Sets Price type.
        /// </summary>
        [Required]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or Sets Unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or Sets Unit price.
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or Sets Vat code id.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or Sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
