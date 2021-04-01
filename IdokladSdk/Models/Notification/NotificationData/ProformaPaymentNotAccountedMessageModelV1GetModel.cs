using System;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// ProformaPaymentNotAccountedMessageModelV1GetModel.
    /// </summary>
    public class ProformaPaymentNotAccountedMessageModelV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets proforma invoice Id.
        /// </summary>
        public int ProformaId { get; set; }
    }
}
