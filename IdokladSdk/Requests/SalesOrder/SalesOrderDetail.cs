using IdokladSdk.Clients;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.SalesOrder
{
    /// <summary>
    /// Sales order detail.
    /// </summary>
    public class SalesOrderDetail : ExpandableDetail<SalesOrderDetail, SalesOrderClient, SalesOrderGetModel, SalesOrderExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderDetail"/> class.
        /// Detail sales receipt.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public SalesOrderDetail(int id, SalesOrderClient client)
            : base(id, client)
        {
        }
    }
}
