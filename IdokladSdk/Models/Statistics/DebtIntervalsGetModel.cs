using System.Collections.Generic;

namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Unpaid issued and received invoices after maturity statistics.
    /// </summary>
    public class DebtIntervalsGetModel
    {
        /// <summary>
        /// Gets or sets issued invoice after maturity statistics.
        /// </summary>
        public IEnumerable<DebtIntervalsItemGetModel> Entry { get; set; }

        /// <summary>
        /// Gets or sets received invoice after maturity statistics.
        /// </summary>
        public IEnumerable<DebtIntervalsItemGetModel> Issue { get; set; }
    }
}
