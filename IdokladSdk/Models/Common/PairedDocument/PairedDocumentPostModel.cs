using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Common.PairedDocument
{
    /// <summary>
    /// POST model for Paired document.
    /// </summary>
    public class PairedDocumentPostModel
    {
        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        [RequiredNonDefault]
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets Document Type.
        /// </summary>
        [RequiredNonDefault]
        public PairedDocumentType DocumentType { get; set; }
    }
}
