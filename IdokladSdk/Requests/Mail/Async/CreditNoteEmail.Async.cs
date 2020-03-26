using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class CreditNoteEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(CreditNoteEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<CreditNoteEmailSettings>(settings, cancellationToken);
        }
    }
}
