using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// RemindedInvoiceNotificationV1GetModel.
    /// </summary>
    public class RemindedInvoiceNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets invoice Id.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets purchaser name.
        /// </summary>
        public string PurchaserName { get; set; }

        /// <summary>
        /// Gets or sets purchaser email.
        /// </summary>
        public string PurchaserMail { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public DocumentType DocumentType { get; set; }
    }
}
