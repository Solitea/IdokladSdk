namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Model for information about VAT record keeping for specific period.
    /// </summary>
    public class DashboardVatSummaryGetModel
    {
        /// <summary>
        /// Gets or sets output tax for last period.
        /// </summary>
        public decimal VatOutLastPeriod { get; set; }

        /// <summary>
        /// Gets or sets output tax for this period.
        /// </summary>
        public decimal VatOutThisPeriod { get; set; }

        /// <summary>
        /// Gets or sets input tax for last period.
        /// </summary>
        public decimal VatInLastPeriod { get; set; }

        /// <summary>
        /// Gets or sets input tax for this period.
        /// </summary>
        public decimal VatInThisPeriod { get; set; }

        /// <summary>
        /// Gets or sets difference for this period.
        /// </summary>
        public decimal DifferenceThisPeriod { get; set; }

        /// <summary>
        /// Gets or sets difference for last period.
        /// </summary>
        public decimal DifferenceLastPeriod { get; set; }
    }
}
