namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// ReferralPointsManualNotificationV1GetModel.
    /// </summary>
    public class ReferralPointsManualNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets credited referral points count.
        /// </summary>
        public decimal Points { get; set; }

        /// <summary>
        /// Gets or sets new referral points count.
        /// </summary>
        public decimal TotalPoints { get; set; }
    }
}
