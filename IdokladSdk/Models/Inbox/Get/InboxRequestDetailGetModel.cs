namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox request detail get model.
    /// </summary>
    public class InboxRequestDetailGetModel : InboxRequestListGetModel
    {
        /// <summary>
        /// Gets or sets message body.
        /// </summary>
        public string Body { get; set; }
    }
}
