using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.IssuedDocumentPayment.Filter;

namespace IdokladSdk.Requests.IssuedDocumentPayment
{
    /// <summary>
    /// List of issued document payments.
    /// </summary>
    public class IssuedDocumentPaymentList : BaseList<IssuedDocumentPaymentList, IssuedDocumentPaymentClient, IssuedDocumentPaymentListGetModel, IssuedDocumentPaymentFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentPaymentList"/> class.
        /// </summary>
        /// <param name="client">Issued document payment client.</param>
        public IssuedDocumentPaymentList(IssuedDocumentPaymentClient client)
            : base(client)
        {
        }
    }
}
