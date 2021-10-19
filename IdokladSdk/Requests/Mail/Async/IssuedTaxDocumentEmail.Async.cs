using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class IssuedTaxDocumentEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<EmailSendResult>> SendAsync(IssuedTaxDocumentEmailSettings settings, CancellationToken cancellationToken = default)
        {
            return SendAsync<IssuedTaxDocumentEmailSettings>(settings, cancellationToken);
        }
    }
}
