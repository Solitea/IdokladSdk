using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class BankAccountClient
    {
        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<BankAccountGetModel>> PostAsync(BankAccountPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<BankAccountPostModel, BankAccountGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<BankAccountGetModel>> UpdateAsync(BankAccountPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<BankAccountPatchModel, BankAccountGetModel>(model, cancellationToken);
        }
    }
}
