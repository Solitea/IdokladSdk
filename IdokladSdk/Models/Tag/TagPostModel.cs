using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Tag
{
    /// <summary>
    /// TagPostModel.
    /// </summary>
    public class TagPostModel
    {
        /// <summary>
        /// Gets or sets the tag color in #rrbbgg or #RRBBGG format.
        /// </summary>
        [Required]
        [Color]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the tag description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
