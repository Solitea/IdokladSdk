namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Debt intervals for unpaid invoices after maturity.
    /// </summary>
    public enum DebtInterval
    {
        /// <summary>
        /// 30 days.
        /// </summary>
        Days30 = 30,

        /// <summary>
        /// 60 days.
        /// </summary>
        Days60 = 60,

        /// <summary>
        /// 90 days.
        /// </summary>
        Days90 = 90,

        /// <summary>
        /// More than 90 days.
        /// </summary>
        Over90Days = 999
    }
}
