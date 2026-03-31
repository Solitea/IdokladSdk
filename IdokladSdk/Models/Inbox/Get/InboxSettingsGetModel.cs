namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox settings get model.
    /// </summary>
    public class InboxSettingsGetModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether active external emails exist.
        /// </summary>
        public bool HasActiveExternalEmails { get; set; }

        /// <summary>
        /// Gets or sets inbox email.
        /// </summary>
        public string InboxEmail { get; set; }
    }
}
