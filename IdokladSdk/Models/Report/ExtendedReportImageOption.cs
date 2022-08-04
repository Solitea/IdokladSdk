using IdokladSdk.Enums;

namespace IdokladSdk.Models.Report
{
    /// <summary>
    /// ExtendedReportImageOption
    /// </summary>
    public class ExtendedReportImageOption : ReportImageOption
    {
        /// <summary>
        /// Gets or sets report payment option.
        /// </summary>
        public PaymentOption PaymentOption { get; set; }
    }
}
