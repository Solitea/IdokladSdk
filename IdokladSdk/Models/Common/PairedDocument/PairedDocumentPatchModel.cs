using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Common.PairedDocument
{
    /// <summary>
    /// PairedDocumentPatchModel.
    /// </summary>
    public class PairedDocumentPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        public int? DocumentId { get; set; }

        /// <summary>
        /// Gets or sets Document Type.
        /// </summary>
        public PairedDocumentType? DocumentType { get; set; }
    }
}
