using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// ReceivedInvoice email.
    /// </summary>
    public partial class ReceivedInvoiceEmail : Email, IEmail<EmailSendResult, ReceivedInvoiceEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedInvoiceEmail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public ReceivedInvoiceEmail(MailClient client)
            : base(client)
        {
            DocumentType = "ReceivedInvoice";
        }

        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(ReceivedInvoiceEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<ReceivedInvoiceEmailSettings>(settings, cancellationToken);
        }
    }
}
