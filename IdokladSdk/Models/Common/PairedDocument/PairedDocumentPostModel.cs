using IdokladSdk.Enums;

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
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets Document Type.
        /// </summary>
        public PairedDocumentType DocumentType { get; set; }
    }
}
