namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Agenda Inbox detail model.
    /// </summary>
    public class AgendaInboxGetModel
    {
        /// <summary>
        /// Indicates whether agenda has inbox registered
        /// </summary>
        public bool HasInbox { get; set; }

        /// <summary>
        /// Indicates whether agenda has inbox enabled
        /// </summary>
        public bool HasActiveExternalEmails { get; set; }

        /// <summary>
        /// Inbox e-mail address
        /// </summary>
        public string InboxEmail { get; set; }

        /// <summary>
        /// Indicates whether agenda has unpaid proforma invoice for AI credits
        /// </summary>
        public bool HasUnpaidProformaForAiCredits { get; set; }
    }
}
