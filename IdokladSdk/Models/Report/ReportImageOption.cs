using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Report
{
    /// <summary>
    /// ReportImageOption.
    /// </summary>
    public class ReportImageOption
    {
        /// <summary>
        /// Gets or sets language.
        /// </summary>
        public Language? Language { get; set; }

        /// <summary>
        /// Gets or sets resolution.
        /// </summary>
        [Range(96, 500)]
        public int? Resolution { get; set; }
    }
}
