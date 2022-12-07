namespace IdokladSdk.Models.Attachment
{
    /// <summary>
    /// GetModel for attachments.
    /// </summary>
    public class AttachmentGetModel
    {
        /// <summary>
        /// Gets or sets filename.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets bytes of a file.
        /// </summary>
        public byte[] FileBytes { get; set; }

        /// <summary xml:lang="en">
        /// Gets or sets entity's Id.
        /// </summary>
        public int Id { get; set; }
    }
}
