namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// QuarterSummaryGetModel.
    /// </summary>
    public class QuarterSummaryGetModel
    {
        /// <summary>
        /// Gets or sets Total billed.
        /// </summary>
        public decimal Billed { get; set; }

        /// <summary>
        /// Gets or sets Position for ordering.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets Quarter title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Total sum of paid invoices.
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// Gets or sets Total sum of proforma invoices.
        /// </summary>
        public decimal TotalProforma { get; set; }

        /// <summary>
        /// Gets or sets Total sum of unpaid invoices.
        /// </summary>
        public decimal TotalUnPaid { get; set; }
    }
}
