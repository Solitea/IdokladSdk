using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class ReceivedInvoiceEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(ReceivedInvoiceEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<ReceivedInvoiceEmailSettings>(settings, cancellationToken);
        }
    }
}
