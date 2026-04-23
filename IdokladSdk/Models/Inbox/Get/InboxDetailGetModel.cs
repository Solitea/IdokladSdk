using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox detail get model.
    /// </summary>
    public class InboxDetailGetModel
    {
        /// <summary>
        /// Gets or sets AI review status.
        /// </summary>
        public InboxAttachmentAiReviewStatus AiReviewStatus { get; set; }

        /// <summary>
        /// Gets or sets attachment.
        /// </summary>
        public InboxAttachmentGetModel Attachment { get; set; }

        /// <summary>
        /// Gets or sets date of processing.
        /// </summary>
        public DateTime? DateOfProcessing { get; set; }

        /// <summary>
        /// Gets or sets inbox item id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets inbox request.
        /// </summary>
        public InboxRequestDetailGetModel InboxRequest { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether source attachment is used.
        /// </summary>
        public bool IsSourceAttachment { get; set; }

        /// <summary>
        /// Gets or sets mined data.
        /// </summary>
        public InboxMinedDataGetModel MinedData { get; set; }

        /// <summary>
        /// Gets or sets percentage of read data.
        /// </summary>
        public int PercentageOfDataRead { get; set; }

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
