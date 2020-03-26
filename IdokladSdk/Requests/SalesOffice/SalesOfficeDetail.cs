using IdokladSdk.Clients;
using IdokladSdk.Models.SalesOffice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.SalesOffice
{
    /// <summary>
    /// Detail of sales office.
    /// </summary>
    public class SalesOfficeDetail : ExpandableDetail<SalesOfficeDetail, SalesOfficeClient, SalesOfficeGetModel, SalesOfficeExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOfficeDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public SalesOfficeDetail(int id, SalesOfficeClient client)
            : base(id, client)
        {
        }
    }
}
