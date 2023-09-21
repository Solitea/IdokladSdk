using IdokladSdk.Clients;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.DocumentPayment.Sales
{
    /// <summary>
    /// CreditNotePaymentDetail.
    /// </summary>
    public class CreditNotePaymentDetail : ExpandableDetail<CreditNotePaymentDetail, DocumentPaymentClient,
        SalesDocumentPaymentForCreditNoteGetModel, SalesDocumentPaymentForCreditNoteExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditNotePaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <param name="client">Credit note payment client.</param>
        public CreditNotePaymentDetail(int id, DocumentPaymentClient client) 
            : base(id, client)
        {
        }

        protected override string DetailName => "Sales/Get/CreditNote/";
    }
}
