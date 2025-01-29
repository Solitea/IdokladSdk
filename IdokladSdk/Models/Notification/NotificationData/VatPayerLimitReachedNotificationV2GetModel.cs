using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// VatPayerLimitReachedNotificationV2GetModel.
    /// </summary>
    public class VatPayerLimitReachedNotificationV2GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets start date of VAT payer limit.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets end date of VAT payer limit.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets VAT Payer Limit Type.
        /// </summary>
        public VatPayerNotificationLimitType VatPayerNotificationLimitType { get; set; }
    }
}
