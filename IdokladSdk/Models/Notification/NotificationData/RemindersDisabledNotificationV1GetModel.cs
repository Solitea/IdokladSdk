using System;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// RemindersDisabledNotificationV1GetModel.
    /// </summary>
    public class RemindersDisabledNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets the date the notifications were blocked.
        /// </summary>
        public DateTime DateOfDisabled { get; set; }
    }
}
