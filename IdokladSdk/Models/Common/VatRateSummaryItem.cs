using IdokladSdk.Enums;

namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// VatRateSummaryItem.
    /// </summary>
    public class VatRateSummaryItem
    {
        /// <summary>
        /// Gets or sets total VAT for given VatRate.
        /// </summary>
        public decimal TotalVat { get; set; }

        /// <summary>
        /// Gets or sets total VAT for given VAT rate type in home currency.
        /// </summary>
        public decimal TotalVatHc { get; set; }

        /// <summary>
        /// Gets or sets total price without VAT for given VAT rate type.
        /// </summary>
        public decimal TotalWithoutVat { get; set; }

        /// <summary>
        /// Gets or sets total price without VAT for given VAT rate type in home currency.
        /// </summary>
        public decimal TotalWithoutVatHc { get; set; }

        /// <summary>
        /// Gets or sets total price with VAT for given VAT rate type.
        /// </summary>
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets total price with VAT for given VAT rate type in home currency.
        /// </summary>
        public decimal TotalWithVatHc { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }

        /// <summary>
        /// Gets or sets VAT rate in percent.
        /// </summary>
        public decimal VatRate { get; set; }
    }
}
