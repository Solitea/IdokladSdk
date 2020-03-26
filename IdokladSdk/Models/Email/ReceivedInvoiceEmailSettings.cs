using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// Settings for sending email with ReceivedInvoice.
    /// </summary>
    public class ReceivedInvoiceEmailSettings : EmailSettings
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

        /// <inheritdoc/>
        public override bool HasRecipients() => SendToAccountant || SendToSelf || OtherRecipients.Any();
    }
}
