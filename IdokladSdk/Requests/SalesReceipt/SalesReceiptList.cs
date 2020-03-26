using IdokladSdk.Clients;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.SalesReceipt.Filter;
using IdokladSdk.Requests.SalesReceipt.Sort;

namespace IdokladSdk.Requests.SalesReceipt
{
    /// <summary>
    /// Sales receipt list.
    /// </summary>
    public class SalesReceiptList : BaseList<SalesReceiptList, SalesReceiptClient, SalesReceiptListGetModel, SalesReceiptFilter, SalesReceiptSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesReceiptList(SalesReceiptClient client)
            : base(client)
        {
        }
    }
}
