using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Inbox.Post
{
    /// <summary>
    /// Inbox attach document post model.
    /// </summary>
    public class InboxAttachDocumentPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets target document id.
        /// </summary>
        [Required]
        [RequiredNonDefault]
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        [Required]
        public InboxAttachmentDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets inbox item id.
        /// </summary>
        [Required]
        [RequiredNonDefault]
        public int Id { get; set; }
    }
}
