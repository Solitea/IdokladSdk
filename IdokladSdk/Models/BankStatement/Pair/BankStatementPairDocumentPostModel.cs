using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankStatement.Pair
{
    /// <summary>
    /// BankStatementPairDocumentPostModel.
    /// </summary>
    public class BankStatementPairDocumentPostModel
    {
        /// <summary>
        /// Gets or sets Bank Statement Id.
        /// </summary>
        [RequiredNonDefault]
        public int BankStatementId { get; set; }

        /// <summary>
        /// Gets or sets Paired document type.
        /// </summary>
        [Required]
        public PairedDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        [RequiredNonDefault]
        public int DocumentId { get; set; }
    }
}
