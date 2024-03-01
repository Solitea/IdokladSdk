using IdokladSdk.Enums;

namespace IdokladSdk.Models.ReceivedDocumentPayments.SubModels
{
    /// <summary>
    /// ReceivedPaymentDocument.
    /// </summary>
    public class ReceivedPaymentDocument
    {
        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public ApiPurchasesPaymentDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }
    }
}
