using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReceivedDocumentPayments
{
    /// <summary>
    /// Detail of received document payment.
    /// </summary>
    public class ReceivedDocumentPaymentDetail :
        ExpandableDetail<ReceivedDocumentPaymentDetail, ReceivedDocumentPaymentsClient, ReceivedDocumentPaymentGetModel, ReceivedDocumentPaymentExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedDocumentPaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <param name="client">Client.</param>
        public ReceivedDocumentPaymentDetail(int id, ReceivedDocumentPaymentsClient client)
            : base(id, client)
        {
        }
    }
}
