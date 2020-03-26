using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class SalesOrderEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(SalesOrderEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<SalesOrderEmailSettings>(settings, cancellationToken);
        }
    }
}
