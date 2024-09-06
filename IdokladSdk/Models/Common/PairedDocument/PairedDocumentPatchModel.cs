using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

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
        [RequiredNonDefault]
        public int? DocumentId { get; set; }

        /// <summary>
        /// Gets or sets Document Type.
        /// </summary>
        [RequiredNonDefault]
        public PairedDocumentType? DocumentType { get; set; }
    }
}
