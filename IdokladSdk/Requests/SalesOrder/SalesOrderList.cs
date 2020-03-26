using IdokladSdk.Clients;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.SalesOrder.Filter;
using IdokladSdk.Requests.SalesOrder.Sort;

namespace IdokladSdk.Requests.SalesOrder
{
    /// <summary>
    /// Sales order list.
    /// </summary>
    public class SalesOrderList : BaseList<SalesOrderList, SalesOrderClient, SalesOrderListGetModel, SalesOrderFilter, SalesOrderSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesOrderList(SalesOrderClient client)
            : base(client)
        {
        }
    }
}
