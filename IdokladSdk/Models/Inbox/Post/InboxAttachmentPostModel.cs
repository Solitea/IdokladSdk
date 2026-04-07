using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Inbox.Post
{
    /// <summary>
    /// Inbox attachment post model.
    /// </summary>
    public class InboxAttachmentPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets base64-encoded attachment content.
        /// </summary>
        [Required]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets file name.
        /// </summary>
        [Required]
        public string FileName { get; set; }
    }
}
