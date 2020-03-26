using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.IssuedDocumentPayment
{
    /// <summary>
    /// Detail of issued document payment item.
    /// </summary>
    public class IssuedDocumentPaymentDetail : ExpandableDetail<IssuedDocumentPaymentDetail, IssuedDocumentPaymentClient, IssuedDocumentPaymentGetModel, IssuedDocumentPaymentExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentPaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Issued document payment item id.</param>
        /// <param name="client">Issued document payment client.</param>
        public IssuedDocumentPaymentDetail(int id, IssuedDocumentPaymentClient client)
            : base(id, client)
        {
        }
    }
}
