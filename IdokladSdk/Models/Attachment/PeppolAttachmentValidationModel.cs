using System.Collections.Generic;

namespace IdokladSdk.Models.Attachment
{
    /// <summary>
    /// Result of Peppol validation of an XML attachment.
    /// </summary>
    public class PeppolAttachmentValidationModel
    {
        /// <summary>Gets or sets validation errors.</summary>
        public IReadOnlyCollection<PeppolErrorModel> Errors { get; set; }

        /// <summary>Gets or sets a value indicating whether the XML attachment is valid.</summary>
        public bool IsValid { get; set; }
    }
}
