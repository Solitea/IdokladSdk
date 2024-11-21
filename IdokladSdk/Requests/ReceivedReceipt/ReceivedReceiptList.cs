using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedReceipt.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.ReceivedReceipt.Filter;
using IdokladSdk.Requests.ReceivedReceipt.Sort;

namespace IdokladSdk.Requests.ReceivedReceipt
{
    /// <summary>
    /// Selectable properties of <see cref="ReceivedReceiptListGetModel"/>.
    /// </summary>
    public class ReceivedReceiptList : BaseList<ReceivedReceiptList, ReceivedReceiptClient, ReceivedReceiptListGetModel, ReceivedReceiptFilter, ReceivedReceiptSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedReceiptList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ReceivedReceiptList(ReceivedReceiptClient client)
            : base(client)
        {
        }
    }
}
