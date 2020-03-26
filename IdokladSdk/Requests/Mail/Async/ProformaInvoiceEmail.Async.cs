using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class ProformaInvoiceEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(ProformaInvoiceEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<ProformaInvoiceEmailSettings>(settings, cancellationToken);
        }
    }
}
