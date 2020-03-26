using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.NumericSequence
{
    /// <summary>
    /// Model for Get endpoints.
    /// </summary>
    public class NumericSequenceGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Document type.
        /// </summary>
        public NumericSequenceDocumentType DocumentType { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the numeric sequence is set as default. New documents without a sequence id specified will have the default sequence set.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets Number of last document. The next document will be saved with the number (LastNumber + 1).
        /// </summary>
        public int LastNumber { get; set; }

        /// <summary>
        /// Gets or sets Additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets Name of the numeric sequence.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Invoice number format (R = year, M = month, N = number).
        /// </summary>
        public string NumberFormat { get; set; }

        /// <summary>
        /// Gets or sets Year of the sequence's validity.
        /// </summary>
        public int Year { get; set; }
    }
}
