using System;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.StockMovement
{
    /// <summary>
    /// StockMovementListGetModel.
    /// </summary>
    public class StockMovementListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets current stock balance.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets date of stock movement.
        /// </summary>
        public DateTime DateOfMovement { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets your note for this stock movement.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets pricelist item reference.
        /// </summary>
        public int PriceListItemId { get; set; }
    }
}
