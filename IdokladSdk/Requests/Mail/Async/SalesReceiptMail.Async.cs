using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class SalesReceiptMail
    {
        /// <inheritdoc />
        public Task<ApiResult<EmailSendResult>> SendAsync(SalesReceiptEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<SalesReceiptEmailSettings>(settings, cancellationToken);
        }
    }
}
