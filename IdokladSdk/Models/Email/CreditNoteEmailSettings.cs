using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Enums;
using Newtonsoft.Json;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// Settings for sending email with CreditNote.
    /// </summary>
    public class CreditNoteEmailSettings : EmailSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to acountant.
        /// The accountant's E-mail and mail template are specified in the application settings.
        /// </summary>
        [Required]
        public bool SendToAccountant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a copy of the e-mail will be sent to your company address.
        /// </summary>
        [Required]
        public bool SendToSelf { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to the partner (purchaser/supplier) specified on the document.
        /// </summary>
        [Required]
        public bool SendToPartner { get; set; }

        /// <summary>
        /// Gets or sets send type - pdf attachment or invoice link.
        /// If not set, the value from your settings will be used.
        /// </summary>
        [JsonProperty("Method")]
        public SendType? SendType { get; set; }

        /// <inheritdoc/>
        public override bool HasRecipients() => SendToAccountant || SendToPartner || SendToSelf || OtherRecipients.Any();
    }
}
