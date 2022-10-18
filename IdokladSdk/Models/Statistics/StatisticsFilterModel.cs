using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Filter for calculation of statistics data for issued and received invoices.
    /// </summary>
    public class StatisticsFilterModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether to include Credit Note Statistics.
        /// </summary>
        public bool IncludeCreditNote { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether to include Issued Invoice Statistics.
        /// </summary>
        public bool IncludeIssuedInvoice { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether to include Received Invoice Statistics.
        /// </summary>
        public bool IncludeReceivedInvoice { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether to include Sales Receipt Statistics.
        /// </summary>
        public bool IncludeSalesReceipt { get; set; } = false;

        /// <summary>
        /// Gets or sets number of periods.
        /// </summary>
        [MinValue(1)]
        public int PeriodsCount { get; set; } = 6;
    }
}
