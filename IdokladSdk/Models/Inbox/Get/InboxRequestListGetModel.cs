using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox request list get model.
    /// </summary>
    public class InboxRequestListGetModel
    {
        /// <summary>
        /// Gets or sets date of receiving.
        /// </summary>
        public DateTime DateOfReceiving { get; set; }

        /// <summary>
        /// Gets or sets inbox request id.
        /// </summary>
        public int InboxRequestId { get; set; }

        /// <summary>
        /// Gets or sets inbox request type.
        /// </summary>
        public InboxRequestType InboxRequestType { get; set; }

        /// <summary>
        /// Gets or sets sender email.
        /// </summary>
        public string SendEmail { get; set; }

        /// <summary>
        /// Gets or sets sender name.
        /// </summary>
        public string SendName { get; set; }

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public string Subject { get; set; }
    }
}
