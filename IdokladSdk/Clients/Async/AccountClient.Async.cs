using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class AccountClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>($"{ResourceUrl}/Users/{id}", cancellationToken);
        }
    }
}
