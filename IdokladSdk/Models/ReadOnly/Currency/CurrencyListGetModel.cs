namespace IdokladSdk.Models.ReadOnly.Currency
{
    /// <summary>
    /// CurrencyListGetModel.
    /// </summary>
    public class CurrencyListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets currency code base on ISO 4217.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets default country's name.
        /// </summary>
        public string CountryName { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets priority of a currency within a system.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string Symbol { get; set; }
    }
}
