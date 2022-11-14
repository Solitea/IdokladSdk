using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Requests.BankAccount;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with bank accounts endpoints.
    /// </summary>
    public class BankAccountClient : BaseClient,
        IDeleteRequest,
        IEntityDetail<BankAccountDetail>,
        IEntityList<BankAccountList>,
        IPatchRequest<BankAccountPatchModel, BankAccountGetModel>,
        IPostRequest<BankAccountPostModel, BankAccountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public BankAccountClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/BankAccounts";

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public BankAccountDetail Detail(int id)
        {
            return new BankAccountDetail(id, this);
        }

        /// <inheritdoc />
        public BankAccountList List()
        {
            return new BankAccountList(this);
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
