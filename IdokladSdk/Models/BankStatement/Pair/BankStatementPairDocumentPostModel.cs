using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

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
        [Required]
        public int BankStatementId { get; set; }

        /// <summary>
        /// Gets or sets Paired document type.
        /// </summary>
        [Required]
        public PairedDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        [Required]
        public int DocumentId { get; set; }
    }
}
