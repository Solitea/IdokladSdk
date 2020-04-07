using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class IssuedDocumentPaymentConfirmationEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<bool>> SendAsync(int settings, CancellationToken cancellationToken = default)
        {
            return Client.PostAsync<bool>(GetResourceUrl(settings), cancellationToken);
        }
    }
}
