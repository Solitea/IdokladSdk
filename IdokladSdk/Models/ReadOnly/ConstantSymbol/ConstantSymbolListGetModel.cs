using System;

namespace IdokladSdk.Models.ReadOnly.ConstantSymbol
{
    /// <summary>
    /// ConstantSymbolListGetModel.
    /// </summary>
    public class ConstantSymbolListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets four-digit code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets country Id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets datum date the entity was last updated.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether constant symbol is default for the country.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets name of constant symbol.
        /// </summary>
        public string Name { get; set; }
    }
}
