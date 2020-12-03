using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.NumericSequence
{
    /// <summary>
    /// NumericSequencePatchModel.
    /// </summary>
    public class NumericSequencePatchModel : ValidatableModel, IEntityId
    {
        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the numeric sequence is set as default. New documents without a sequence id specified will have the default sequence set.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets number of last document. The next document will be saved with the number (LastNumber + 1).
        /// </summary>
        [Range(0, int.MaxValue)]
        public int? LastNumber { get; set; }

        /// <summary>
        /// Gets or sets name of the numeric sequence.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets invoice number format (R = year, M = month, N = number).
        /// </summary>
        public string NumberFormat { get; set; }

        /// <summary>
        /// Gets or sets year of the sequence's validity.
        /// </summary>
        public int? Year { get; set; }
    }
}
