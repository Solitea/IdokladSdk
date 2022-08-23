using System;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// ProformaInvoice email.
    /// </summary>
    public partial class ProformaInvoiceEmail : Email, IEmail<EmailSendResult, ProformaInvoiceEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProformaInvoiceEmail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public ProformaInvoiceEmail(MailClient client)
            : base(client)
        {
            DocumentType = "ProformaInvoice";
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<EmailSendResult> Send(ProformaInvoiceEmailSettings settings)
        {
            return SendAsync(settings).GetAwaiter().GetResult();
        }
    }
}
