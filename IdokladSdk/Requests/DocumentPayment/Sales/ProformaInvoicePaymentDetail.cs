using IdokladSdk.Clients;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.DocumentPayment.Sales
{
    /// <summary>
    /// ProformaInvoicePaymentDetail.
    /// </summary>
    public class ProformaInvoicePaymentDetail : ExpandableDetail<ProformaInvoicePaymentDetail, DocumentPaymentClient,
        SalesDocumentPaymentForProformaInvoiceGetModel, SalesDocumentPaymentForProformaInvoiceExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProformaInvoicePaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <param name="client">Proforma invoice payment client.</param>
        public ProformaInvoicePaymentDetail(int id, DocumentPaymentClient client) 
            : base(id, client)
        {
        }

        protected override string DetailName => "Sales/Get/ProformaInvoice/";
    }
}
