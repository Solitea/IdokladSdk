using IdokladSdk.Clients;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.DocumentPayment.Sales
{
    /// <summary>
    /// IssuedInvoicePaymentDetail.
    /// </summary>
    public class IssuedInvoicePaymentDetail : ExpandableDetail<IssuedInvoicePaymentDetail, DocumentPaymentClient,
        SalesDocumentPaymentForIssuedInvoiceGetModel, SalesDocumentPaymentForIssuedInvoiceExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoicePaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <param name="client">Issued invoice payment client.</param>
        public IssuedInvoicePaymentDetail(int id, DocumentPaymentClient client) 
            : base(id, client)
        {
        }

        protected override string DetailName => "Sales/Get/IssuedInvoice/";
    }
}
