using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Inbox.Post
{
    /// <summary>
    /// Inbox AI review post model.
    /// </summary>
    public class InboxAIReviewPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets inbox item id.
        /// </summary>
        [Required]
        [RequiredNonDefault]
        public int Id { get; set; }
    }
}
