using IdokladSdk.Enums;

namespace IdokladSdk.Models.Report
{
    /// <summary>
    /// ExtendedReportOption.
    /// </summary>
    public class ExtendedReportOption : ReportOption
    {
        /// <summary>
        /// Gets or sets report payment option.
        /// </summary>
        public PaymentOption PaymentOption { get; set; }
    }
}
