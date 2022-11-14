using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// Sales receipt email.
    /// </summary>
    public partial class SalesReceiptMail : Email, IEmail<EmailSendResult, SalesReceiptEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptMail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public SalesReceiptMail(MailClient client)
            : base(client)
        {
            DocumentType = "SalesReceipt";
        }

        /// <inheritdoc />
        public Task<ApiResult<EmailSendResult>> SendAsync(SalesReceiptEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<SalesReceiptEmailSettings>(settings, cancellationToken);
        }
    }
}
