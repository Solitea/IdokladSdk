using IdokladSdk.Enums;

namespace IdokladSdk.Models.Common.PairedDocument
{
    /// <summary>
    /// Paired Document Get Model.
    /// </summary>
    public class PairedDocumentGetModel
    {
        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets Document Number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets Document Type.
        /// </summary>
        public PairedDocumentType DocumentType { get; set; }
    }
}
