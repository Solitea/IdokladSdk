using System;

namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// Metadata of a model.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Gets or sets date when the entity was last created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was last changed.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <summary>
        /// Gets or sets Id of the user who created the entity.
        /// </summary>
        public int? UserCreatedId { get; set; }

        /// <summary>
        /// Gets or sets Id of the user who last changed the entity.
        /// </summary>
        public int? UserLastChangeId { get; set; }
    }
}
