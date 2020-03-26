using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class BankStatementClient
    {
        /// <inheritdoc cref="Pair"/>
        public Task<ApiResult<BankStatementPairingResult>> PairAsync(BankStatementPairingPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Pair";
            return PostAsync<BankStatementPairingPostModel, BankStatementPairingResult>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, default);
        }
    }
}
