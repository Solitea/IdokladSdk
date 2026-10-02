namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// InboxMailAttachmentCreatedMessageModelV1GetModel.
    /// </summary>
    public class InboxMailAttachmentCreatedMessageModelV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets filename from email attachment.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets email subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets email sender.
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets id of inbox attachment.
        /// </summary>
        public int InboxAttachmentId { get; set; }
    }
}
