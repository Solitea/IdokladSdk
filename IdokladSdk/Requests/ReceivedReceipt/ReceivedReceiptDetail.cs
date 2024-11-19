using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedReceipt.Get;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReceivedReceipt
{
    /// <summary>
    /// Detail of received receipt.
    /// </summary>
    public class ReceivedReceiptDetail : ExpandableDetail<ReceivedReceiptDetail, ReceivedReceiptClient,
        ReceivedReceiptGetModel, ReceivedReceiptExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedReceiptDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public ReceivedReceiptDetail(int id, ReceivedReceiptClient client)
            : base(id, client)
        {
        }
    }
}
