using System;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// EetCertificateExpireSoonNotificationV1GetModel.
    /// </summary>
    public class EetCertificateExpireSoonNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets certificate name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets certificate expire date.
        /// </summary>
        public DateTime ExpireDate { get; set; }
    }
}
