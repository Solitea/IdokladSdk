using System;

namespace IdokladSdk.Models.ReadOnly.ExchangeRate
{
    /// <summary>
    /// ExchangeRateListGetModel.
    /// </summary>
    public class ExchangeRateListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of exchange rate publishing.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was last changed.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <summary>
        /// Gets or sets exchange rate list id. 1 = ČNB, 2 = ECB.
        /// </summary>
        public int ExchangeListId { get; set; }

        /// <summary>
        /// Gets or sets exchange rate value.
        /// </summary>
        public decimal ExchangeRateValue { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }
    }
}
