using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Inbox.Post
{
    /// <summary>
    /// Inbox post model.
    /// </summary>
    public class InboxPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets uploaded attachments.
        /// </summary>
        [Required]
        [MinCollectionLength(1)]
        public List<InboxAttachmentPostModel> Attachments { get; set; }
    }
}
