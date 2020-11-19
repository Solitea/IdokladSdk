using System;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// ReferralPromoCodeExpiredSoonNotificationV1GetModel.
    /// </summary>
    public class ReferralPromoCodeExpiredSoonNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets referral points count, which are going to expire.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets date of expiration.
        /// </summary>
        public DateTime DateExpiration { get; set; }
    }
}
