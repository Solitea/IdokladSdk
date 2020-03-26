using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.StockMovement
{
    /// <summary>
    /// StockMovementPostModel.
    /// </summary>
    public class StockMovementPostModel
    {
        /// <summary>
        /// Gets or sets current stock balance.
        /// </summary>
        [CannotEqual(0, "The amount must be either positive or negative.")]
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets date of stock movement.
        /// </summary>
        [Required]
        public DateTime DateOfMovement { get; set; }

        /// <summary>
        /// Gets or sets your note for this stock movement.
        /// </summary>
        [StringLength(100)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets pricelist item reference.
        /// </summary>
        [RequiredNonDefault]
        public int PriceListItemId { get; set; }
    }
}
