using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// SupportNotificationV1GetModel.
    /// </summary>
    public class SupportNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets thread author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets date of thread creation.
        /// </summary>
        public DateTime DateOfAction { get; set; }

        /// <summary>
        /// Gets or sets thread guid.
        /// </summary>
        public Guid? ThreadGuid { get; set; }

        /// <summary>
        /// Gets or sets thread name.
        /// </summary>
        public string ThreadName { get; set; }

        /// <summary>
        /// Gets or sets thread item type.
        /// </summary>
        public ThreadItemType ThreadItemType { get; set; }
    }
}
