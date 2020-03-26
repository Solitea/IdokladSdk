using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.Models.ReadOnly.Bank
{
    /// <summary>
    /// BankGetModel.
    /// </summary>
    public class BankGetModel : BankListGetModel
    {
        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public CountryGetModel Country { get; set; }
    }
}
