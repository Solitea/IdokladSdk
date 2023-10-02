using IdokladSdk.Enums;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// SalesSettingsGetModel.
    /// </summary>
    public class SalesSettingsGetModel
    {
        /// <summary>
        /// Gets or sets default invoice maturity.
        /// </summary>
        public int DefaultInvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets default price type.
        /// </summary>
        public PriceType DefaultPriceType { get; set; }

        /// <summary>
        /// Gets or sets default VAT code ID.
        /// </summary>
        public int? DefaultVatCodeId { get; set; }

        /// <summary>
        /// Gets or sets default VAT rate.
        /// </summary>
        public VatRateType DefaultVatRate { get; set; }

        /// <summary>
        /// Gets or sets text preceding invoice items.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets text following invoice items.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets text preceding proforma invoice items.
        /// </summary>
        public string ProformaItemsPrefixText { get; set; }

        /// <summary>
        /// Gets or sets text following proforma invoice items.
        /// </summary>
        public string ProformaItemsSuffixText { get; set; }
    }
}
