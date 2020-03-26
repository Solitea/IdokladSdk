using System;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.CashRegister
{
    /// <summary>
    /// CashRegisterListGetModel.
    /// </summary>
    public class CashRegisterListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date when the intial state was set.
        /// </summary>
        public DateTime? DateInitialState { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets initial amout of money in the cash register.
        /// </summary>
        public decimal? InitialState { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets cash register name.
        /// </summary>
        public string Name { get; set; }
    }
}
