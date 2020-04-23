using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class RemindersEmail
    {
        /// <inheritdoc />
        public Task<ApiResult<EmailSendResult>> SendAsync(RemindersEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<RemindersEmailSettings>(settings, cancellationToken);
        }
    }
}
