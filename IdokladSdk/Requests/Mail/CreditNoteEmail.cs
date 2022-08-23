using System;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// CreditNote email.
    /// </summary>
    public partial class CreditNoteEmail : Email, IEmail<EmailSendResult, CreditNoteEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditNoteEmail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public CreditNoteEmail(MailClient client)
            : base(client)
        {
            DocumentType = "CreditNote";
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<EmailSendResult> Send(CreditNoteEmailSettings settings)
        {
            return SendAsync(settings).GetAwaiter().GetResult();
        }
    }
}
