using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// VatPayerLimitReachedNotificationV1GetModel.
    /// </summary>
    public class VatPayerLimitReachedNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets date of limit reached.
        /// </summary>
        public DateTime DateOfEvent { get; set; }

        /// <summary>
        /// Gets or sets accounting type.
        /// </summary>
        public AccountingType AccountingType { get; set; }

        /// <summary>
        /// Gets or sets legislation.
        /// </summary>
        public LegislationType Legislation { get; set; }
    }
}
