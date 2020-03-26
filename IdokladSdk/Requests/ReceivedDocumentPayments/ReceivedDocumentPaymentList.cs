using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReceivedDocumentPayments.Filter;

namespace IdokladSdk.Requests.ReceivedDocumentPayments
{
    /// <summary>
    /// List of received document payments.
    /// </summary>
    public class ReceivedDocumentPaymentList :
        BaseList<ReceivedDocumentPaymentList, ReceivedDocumentPaymentsClient, ReceivedDocumentPaymentListGetModel, ReceivedDocumentPaymentFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedDocumentPaymentList"/> class.
        /// </summary>
        /// <param name="client">Received document payments client.</param>
        public ReceivedDocumentPaymentList(ReceivedDocumentPaymentsClient client)
            : base(client)
        {
        }
    }
}
