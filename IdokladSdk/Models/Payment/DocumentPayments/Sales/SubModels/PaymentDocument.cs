using IdokladSdk.Enums;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.SubModels
{
    /// <summary>
    /// PaymentDocument.
    /// </summary>
    public class PaymentDocument
    {
        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public ApiSalesPaymentDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }
    }
}
