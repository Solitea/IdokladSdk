using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.Country;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.Country.Filter;

namespace IdokladSdk.Requests.ReadOnly.Country
{
    /// <summary>
    /// List of countries.
    /// </summary>
    public class CountryList : BaseList<CountryList, CountryClient, CountryListGetModel, CountryFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryList"/> class.
        /// </summary>
        /// <param name="client">Country client.</param>
        public CountryList(CountryClient client)
            : base(client)
        {
        }
    }
}
