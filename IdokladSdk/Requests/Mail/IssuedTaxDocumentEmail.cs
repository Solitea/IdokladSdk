using System;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class IssuedTaxDocumentEmail : Email, IEmail<EmailSendResult, IssuedTaxDocumentEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedTaxDocumentEmail"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public IssuedTaxDocumentEmail(MailClient client)
            : base(client)
        {
            DocumentType = "IssuedTaxDocument";
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<EmailSendResult> Send(IssuedTaxDocumentEmailSettings settings)
        {
            return SendAsync(settings).GetAwaiter().GetResult();
        }
    }
}
