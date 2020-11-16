using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// RecurringOrderNotificationV1GetModel.
    /// </summary>
    public class RecurringOrderNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets payment state.
        /// </summary>
        public RecurringPaymentState? PaymentState { get; set; }
    }
}
