using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Serialization;
using Newtonsoft.Json;

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
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DateInitialState { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets initial amout of money in the cash register.
        /// </summary>
        public decimal? InitialState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cash register is default.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cash register is connected to EET sales pos equipment.
        /// </summary>
        public bool IsEet { get; set; }

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
