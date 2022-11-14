using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.CashRegister;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with cash register endpoints.
    /// </summary>
    public class CashRegisterClient : BaseClient,
        IDeleteRequest,
        IEntityDetail<CashRegisterDetail>,
        IEntityList<CashRegisterList>,
        IPatchRequest<CashRegisterPatchModel, CashRegisterGetModel>,
        IPostRequest<CashRegisterPostModel, CashRegisterGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashRegisterClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public CashRegisterClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/CashRegisters";

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public CashRegisterDetail Detail(int id)
        {
            return new CashRegisterDetail(id, this);
        }

        /// <inheritdoc/>
        public CashRegisterList List()
        {
            return new CashRegisterList(this);
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
