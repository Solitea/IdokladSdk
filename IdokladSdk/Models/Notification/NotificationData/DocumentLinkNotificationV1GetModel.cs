using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Notification.NotificationData
{
    /// <summary>
    /// DocumentLinkNotificationV1GetModel.
    /// </summary>
    public class DocumentLinkNotificationV1GetModel : NotificationDataGetModel
    {
        /// <summary>
        /// Gets or sets date of activation.
        /// </summary>
        public DateTime DateOfActivation { get; set; }

        /// <summary>
        /// Gets or sets document id.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets recipient email.
        /// </summary>
        public string RecepientEmail { get; set; }

        /// <summary>
        /// Gets or sets company name.
        /// </summary>
        public string CompanyName { get; set; }
    }
}
