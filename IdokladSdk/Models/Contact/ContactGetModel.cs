using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.Models.Contact
{
    /// <summary>
    /// Model for Get endpoints.
    /// </summary>
    public class ContactGetModel : ContactListGetModel
    {
        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public CountryGetModel Country { get; set; }

        /// <summary>
        /// Gets or sets bank.
        /// </summary>
        public BankGetModel Bank { get; set; }
    }
}
