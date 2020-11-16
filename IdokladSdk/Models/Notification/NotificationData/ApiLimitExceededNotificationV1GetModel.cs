using System;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// ApiLimitExceededNotificationV1GetModel.
    /// </summary>
    public class ApiLimitExceededNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets limit on the number of requests.
        /// </summary>
        public long LimitValue { get; set; }

        /// <summary>
        /// Gets or sets actual requests count.
        /// </summary>
        public long ActualRequestCount { get; set; }

        /// <summary>
        /// Gets or sets requests count renewal date.
        /// </summary>
        public DateTime DateOfRenewal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether requests count is exceeded.
        /// </summary>
        public bool IsExeeded { get; set; }
    }
}
