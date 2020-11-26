using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class CashRegisterClient
    {
        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<CashRegisterGetModel>> PostAsync(CashRegisterPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<CashRegisterPostModel, CashRegisterGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<CashRegisterGetModel>> UpdateAsync(CashRegisterPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<CashRegisterPatchModel, CashRegisterGetModel>(model, cancellationToken);
        }
    }
}
