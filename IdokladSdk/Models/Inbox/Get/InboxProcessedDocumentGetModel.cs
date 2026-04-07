using IdokladSdk.Enums;

namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox processed document get model.
    /// </summary>
    public class InboxProcessedDocumentGetModel
    {
        /// <summary>
        /// Gets or sets processed document id.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets processed document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets processed document type.
        /// </summary>
        public InboxAttachmentDocumentType DocumentType { get; set; }
    }
}
