namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Intervals for unpaid invoice statistics.
    /// </summary>
    public class DebtIntervalsItemGetModel
    {
        /// <summary>
        /// Gets or sets unpaid invoice statistics interval.
        /// </summary>
        public DebtInterval Interval { get; set; }

        /// <summary>
        /// Gets or sets unpaid invoice statistics interval description.
        /// </summary>
        public string IntervalDescription { get; set; }

        /// <summary>
        /// Gets or sets total debt for particular interval.
        /// </summary>
        public decimal TotalDebt { get; set; }
    }
}
