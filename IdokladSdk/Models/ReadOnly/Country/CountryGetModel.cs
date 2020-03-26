using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.ReadOnly.Country
{
    /// <summary>
    /// CountryGetModel.
    /// </summary>
    public class CountryGetModel : CountryListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }
    }
}
