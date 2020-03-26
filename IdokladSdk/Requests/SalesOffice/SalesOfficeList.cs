using IdokladSdk.Clients;
using IdokladSdk.Models.SalesOffice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.SalesOffice.Filter;

namespace IdokladSdk.Requests.SalesOffice
{
    /// <summary>
    /// List of sales offices.
    /// </summary>
    public class SalesOfficeList : BaseList<SalesOfficeList, SalesOfficeClient, SalesOfficeListGetModel, SalesOfficeFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOfficeList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesOfficeList(SalesOfficeClient client)
            : base(client)
        {
        }
    }
}
