using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// BankStatementNotificationV1GetModel.
    /// </summary>
    public class BankStatementNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether bank statement is paired with document.
        /// </summary>
        public bool IsPaired { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets paid amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets bank statement Id.
        /// </summary>
        public int BankStatementId { get; set; }

        /// <summary>
        /// Gets or sets paired document Id.
        /// </summary>
        public int PairedDocumentId { get; set; }

        /// <summary>
        /// Gets or sets paired document type.
        /// </summary>
        public DocumentType PairedDocumentType { get; set; }

        /// <summary>
        /// Gets or sets paired invoice document number.
        /// </summary>
        public string PairedInvoiceDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets invoice payment status.
        /// </summary>
        public PaymentStatus InvoicePaymentStatus { get; set; }
    }
}
