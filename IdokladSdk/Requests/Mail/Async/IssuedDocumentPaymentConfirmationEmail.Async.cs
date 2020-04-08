using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public partial class IssuedDocumentPaymentConfirmationEmail
    {
        /// <inheritdoc/>
        public Task<ApiResult<bool>> SendAsync(int id, CancellationToken cancellationToken = default)
        {
            return Client.PostAsync<bool>(GetResourceUrl(id), cancellationToken);
        }
    }
}
