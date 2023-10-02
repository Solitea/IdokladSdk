using IdokladSdk.Enums;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Copy
{
    /// <summary>
    /// IssuedDocumentTemplateItemCopyGetModel.
    /// </summary>
    public class IssuedDocumentTemplateItemCopyGetModel
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public IssuedDocumentTemplateItemGetType ItemType { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets vat code id.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vat rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
