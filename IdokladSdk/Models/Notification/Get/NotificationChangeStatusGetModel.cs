using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.Get
{
    /// <summary>
    /// Notification change status get model.
    /// </summary>
    public class NotificationChangeStatusGetModel
    {
        /// <summary>
        /// Gets or Sets Notification Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Notification Status.
        /// </summary>
        public NotificationUserStatus Status { get; set; }
    }
}
