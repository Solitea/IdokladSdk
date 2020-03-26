using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// ProformaInvoice email.
    /// </summary>
    public partial class ProformaInvoiceEmail : Email, IEmail<ProformaInvoiceEmailSettings>
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
        public ApiResult<EmailSendResult> Send(ProformaInvoiceEmailSettings settings)
        {
            return Send<ProformaInvoiceEmailSettings>(settings);
        }
    }
}
