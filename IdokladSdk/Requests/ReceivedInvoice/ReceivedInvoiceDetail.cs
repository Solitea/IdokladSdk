using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReceivedInvoice
{
    /// <summary>
    /// Detail of received invoice.
    /// </summary>
    public class ReceivedInvoiceDetail : ExpandableDetail<ReceivedInvoiceDetail, ReceivedInvoiceClient, ReceivedInvoiceGetModel, ReceivedInvoiceExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedInvoiceDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public ReceivedInvoiceDetail(int id, ReceivedInvoiceClient client)
            : base(id, client)
        {
        }
    }
}
