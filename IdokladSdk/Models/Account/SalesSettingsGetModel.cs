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
    }
}
