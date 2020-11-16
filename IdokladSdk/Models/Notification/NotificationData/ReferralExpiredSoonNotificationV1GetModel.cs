using System;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// ReferralExpiredSoonNotificationV1GetModel.
    /// </summary>
    public class ReferralExpiredSoonNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets referral points created date.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets referral points count.
        /// </summary>
        public decimal Points { get; set; }
    }
}
