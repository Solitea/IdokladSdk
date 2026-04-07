namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox attachment list model.
    /// </summary>
    public class InboxAttachmentListGetModel
    {
        /// <summary>
        /// Gets or sets original file name.
        /// </summary>
        public string FileOriginalName { get; set; }

        /// <summary>
        /// Gets or sets attachment id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the attachment is unsupported.
        /// </summary>
        public bool IsUnsupported { get; set; }
    }
}
