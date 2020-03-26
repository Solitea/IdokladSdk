using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class IssuedInvoiceEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(IssuedInvoiceEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<IssuedInvoiceEmailSettings>(settings, cancellationToken);
        }
    }
}
