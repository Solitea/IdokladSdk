using System.Collections.Generic;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// The result of sending emails.
    /// </summary>
    public class EmailSendResult
    {
        /// <summary>
        /// Gets or sets emails not sent.
        /// </summary>
        public IEnumerable<string> NotSent { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets emails sent.
        /// </summary>
        public IEnumerable<string> Sent { get; set; } = new List<string>();
    }
}
