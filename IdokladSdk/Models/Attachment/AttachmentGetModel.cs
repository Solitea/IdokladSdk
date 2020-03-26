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
    }
}
