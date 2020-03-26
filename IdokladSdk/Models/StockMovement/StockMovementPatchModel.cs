using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.StockMovement
{
    /// <summary>
    /// StockMovementPatchModel.
    /// </summary>
    public class StockMovementPatchModel : IEntityId
    {
        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets your note for this stock movement.
        /// </summary>
        [StringLength(100)]
        public string Note { get; set; }
    }
}
