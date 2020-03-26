using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.Country;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReadOnly.Country
{
    /// <summary>
    /// Detail of country.
    /// </summary>
    public class CountryDetail : ExpandableDetail<CountryDetail, CountryClient, CountryGetModel, CountryExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDetail"/> class.
        /// </summary>
        /// <param name="id">Country id.</param>
        /// <param name="client">Country client.</param>
        public CountryDetail(int id, CountryClient client)
            : base(id, client)
        {
        }
    }
}
