using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Tag
{
    /// <summary>
    /// TagPatchModel.
    /// </summary>
    public class TagPatchModel : IEntityId
    {
        /// <summary>
        /// Gets or sets the tag color in #rrbbgg or #RRBBGG format.
        /// </summary>
        [Color]
        public string Color { get; set; }

        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag description.
        /// </summary>
        [StringLength(50)]
        [NotEmptyString]
        public string Name { get; set; }
    }
}
