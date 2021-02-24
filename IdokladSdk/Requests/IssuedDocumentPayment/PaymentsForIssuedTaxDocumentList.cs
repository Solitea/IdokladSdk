using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.IssuedDocumentPayment.Filter;

namespace IdokladSdk.Requests.IssuedDocumentPayment
{
    /// <summary>
    /// PaymentsForIssuedTaxDocumentList.
    /// </summary>
    public class PaymentsForIssuedTaxDocumentList : BaseList<PaymentsForIssuedTaxDocumentList, IssuedDocumentPaymentClient, IssuedDocumentPaymentGetModel, PaymentsForIssuedTaxDocumentFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsForIssuedTaxDocumentList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public PaymentsForIssuedTaxDocumentList(IssuedDocumentPaymentClient client)
        : base(client)
        {
        }

        /// <inheritdoc/>
        protected override string ListName { get; set; } = "PaymentsForIssuedTaxDocument";
    }
}
