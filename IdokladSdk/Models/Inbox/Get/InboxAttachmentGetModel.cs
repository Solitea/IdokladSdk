using IdokladSdk.Enums;

namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox attachment detail model.
    /// </summary>
    public class InboxAttachmentGetModel
    {
        /// <summary>
        /// Gets or sets attachment original file name.
        /// </summary>
        public string AttachmentFileOriginalName { get; set; }

        /// <summary>
        /// Gets or sets attachment id.
        /// </summary>
        public int AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets attachment size.
        /// </summary>
        public int AttachmentSize { get; set; }

        /// <summary>
        /// Gets or sets storage type.
        /// </summary>
        public AttachmentStorageType StorageType { get; set; }

        /// <summary>
        /// Gets or sets storage URL.
        /// </summary>
        public string StorageUrl { get; set; }
    }
}
