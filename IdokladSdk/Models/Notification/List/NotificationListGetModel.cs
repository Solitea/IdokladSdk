using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Notification.NotificationData;
using IdokladSdk.Serialization;
using Newtonsoft.Json;

namespace IdokladSdk.Models.Notification.List
{
    /// <summary>
    /// NotificationListGetModel.
    /// </summary>
    [JsonConverter(typeof(NotificationJsonConverter))]
    public class NotificationListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets notification body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets notification data.
        /// </summary>
        public NotificationDataGetModel NotificationData { get; set; }

        /// <summary>
        /// Gets or sets notification data type.
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// Gets or sets notification status.
        /// </summary>
        public NotificationUserStatus Status { get; set; }

        /// <summary>
        /// Gets or sets notification date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets notification title.
        /// </summary>
        public string Title { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets notification severity.
        /// </summary>
        public NotificationSeverityType SeverityType { get; set; }

        /// <summary>
        /// Gets or sets notification type.
        /// </summary>
        public NotificationType Type { get; set; }
    }
}
