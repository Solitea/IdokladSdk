using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// CreditNote email.
    /// </summary>
    public class CreditNoteEmail : Email, IEmail<EmailSendResult, CreditNoteEmailSettings>
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
        public Task<ApiResult<EmailSendResult>> SendAsync(CreditNoteEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<CreditNoteEmailSettings>(settings, cancellationToken);
        }
    }
}
