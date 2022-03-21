using IdokladSdk.Enums;

namespace IdokladSdk.Models.Report
{
    /// <summary>
    /// ReportOption.
    /// </summary>
    public class ReportOption
    {
        /// <summary>
        /// Gets or sets a value indicating whether compressed.
        /// </summary>
        public bool Compressed { get; set; }

        /// <summary>
        /// Gets or sets language.
        /// </summary>
        public Language? Language { get; set; }
    }
}
