using System;

namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Model contains information about VAT payer progress and its limits.
    /// </summary>
    public class VatPayerProgressGetModel
    {
        /// <summary>
        /// Gets or sets start of the auditing period.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets end of the auditing period.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets total sale value for the auditing period.
        /// </summary>
        public decimal TotalSaleHc { get; set; }

        /// <summary>
        /// Gets or sets vat payer limit.
        /// </summary>
        public decimal VatPayerLimit { get; set; }
    }
}
