using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.ReadOnly.ExchangeRate
{
    /// <summary>
    /// ExchangeRateGeModel.
    /// </summary>
    public class ExchangeRateGetModel : ExchangeRateListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }
    }
}
