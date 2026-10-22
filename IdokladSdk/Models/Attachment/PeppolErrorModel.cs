using IdokladSdk.Enums;

namespace IdokladSdk.Models.Attachment
{
    /// <summary>
    /// Peppol validation error.
    /// </summary>
    public class PeppolErrorModel
    {
        /// <summary>Gets or sets the location of the error.</summary>
        public string Location { get; set; }

        /// <summary>Gets or sets the error message.</summary>
        public string Message { get; set; }

        /// <summary>Gets or sets the validation rule identifier.</summary>
        public string RuleId { get; set; }

        /// <summary>Gets or sets the validation stage.</summary>
        public ApiPeppolValidationStage Stage { get; set; }
    }
}
