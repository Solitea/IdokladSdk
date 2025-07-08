using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Notification.Put
{
    /// <summary>
    /// Notification Put Model.
    /// </summary>
    public class NotificationPutModel : ValidatableModel
    {
        /// <summary>
        /// Gets or Sets Notification Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Notification status.
        /// </summary>
        [Required]
        public NotificationUserStatus Status { get; set; }
    }
}
