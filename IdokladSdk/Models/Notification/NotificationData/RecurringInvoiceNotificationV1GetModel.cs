using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// RecurringInvoiceNotificationV1GetModel.
    /// </summary>
    public class RecurringInvoiceNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets invoice number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets purchaser name.
        /// </summary>
        public string PurchaserName { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public DocumentType DocumentType { get; set; }
    }
}
