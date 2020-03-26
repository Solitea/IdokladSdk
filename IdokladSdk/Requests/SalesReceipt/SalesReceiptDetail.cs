using IdokladSdk.Clients;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.SalesReceipt
{
    /// <summary>
    /// Sales receipt detail.
    /// </summary>
    public class SalesReceiptDetail :
        ExpandableDetail<SalesReceiptDetail, SalesReceiptClient, SalesReceiptGetModel, SalesReceiptExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptDetail"/> class.
        /// Detail sales receipt.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public SalesReceiptDetail(int id, SalesReceiptClient client)
            : base(id, client)
        {
        }
    }
}
