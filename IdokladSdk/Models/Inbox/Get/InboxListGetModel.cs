using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox list get model.
    /// </summary>
    public class InboxListGetModel
    {
        /// <summary>
        /// Gets or sets AI review status.
        /// </summary>
        public InboxAttachmentAiReviewStatus AiReviewStatus { get; set; }

        /// <summary>
        /// Gets or sets attachment.
        /// </summary>
        public InboxAttachmentListGetModel Attachment { get; set; }

        /// <summary>
        /// Gets or sets date of processing.
        /// </summary>
        public DateTime DateOfProcessing { get; set; }

        /// <summary>
        /// Gets or sets inbox item id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets inbox request.
        /// </summary>
        public InboxRequestListGetModel InboxRequest { get; set; }

        /// <summary>
        /// Gets or sets percentage of read data.
        /// </summary>
        public int PercentageOfReadData { get; set; }

        /// <summary>
        /// Gets or sets processed document.
        /// </summary>
        public InboxProcessedDocumentGetModel ProcessedDocument { get; set; }

        /// <summary>
        /// Gets or sets attachment type.
        /// </summary>
        public InboxAttachmentType Type { get; set; }

        /// <summary>
        /// Gets or sets attachment status.
        /// </summary>
        public InboxAttachmentStatus Status { get; set; }
    }
}
