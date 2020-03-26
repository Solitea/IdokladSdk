using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// Base settings for sending email.
    /// </summary>
    public abstract class EmailSettings
    {
        /// <summary>
        /// Gets or sets id of the document to send.
        /// </summary>
        [RequiredNonDefault]
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets custom e-mail body. Can contain placeholders. If not set, the default from your settings will be used.
        /// </summary>
        public string EmailBody { get; set; }

        /// <summary>
        /// Gets or sets custom e-mail subject. If not set, the default from your settings will be used.
        /// </summary>
        public string EmailSubject { get; set; }

        /// <summary>
        /// Gets or sets list of other recipients.
        /// </summary>
        [CollectionRange(0, 5)]
        [EmailCollection(ErrorMessage = "OtherRecipients have to contain valid email adresses.")]
        public IList<string> OtherRecipients { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets document language.
        /// </summary>
        public Language? ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include the document's attachment if it has one.
        /// Default is <c>true</c>.
        /// </summary>
        public bool SendAttachment { get; set; } = true;

        /// <summary>
        /// Validates settings.
        /// </summary>
        /// <returns><c>true</c> if email settings are valid, otherwise <c>false</c>.</returns>
        public abstract bool HasRecipients();
    }
}
