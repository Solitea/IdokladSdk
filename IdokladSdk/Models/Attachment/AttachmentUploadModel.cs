using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Attachment
{
    /// <summary>
    /// Model for uploading attachments.
    /// </summary>
    public class AttachmentUploadModel : IFile
    {
        /// <summary>
        /// Gets or sets filename.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets bytes of a file.
        /// </summary>
        public byte[] FileBytes { get; set; }

        /// <summary>
        /// Gets or sets documentId.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public AttachmentDocumentType DocumentType { get; set; }
    }
}
