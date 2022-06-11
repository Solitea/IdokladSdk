using System;

namespace IdokladSdk.Models.Tag
{
    /// <summary>
    /// TagGetModel.
    /// </summary>
    public class TagListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets the tag color in #rrbbgg format.
        /// </summary>
        [Obsolete("Tag color is no longer supported")]
        public string Color { get; set; }

        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag description.
        /// </summary>
        public string Name { get; set; }
    }
}
