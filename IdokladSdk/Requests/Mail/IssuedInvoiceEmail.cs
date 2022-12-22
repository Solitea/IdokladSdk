using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// IssuedInvoice email.
    /// </summary>
    public partial class IssuedInvoiceEmail : Email, IEmail<EmailSendResult, IssuedInvoiceEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceEmail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public IssuedInvoiceEmail(MailClient client)
            : base(client)
        {
            DocumentType = "IssuedInvoice";
        }

        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(IssuedInvoiceEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<IssuedInvoiceEmailSettings>(settings, cancellationToken);
        }
    }
}
