using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.BankStatement;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with bank statement endpoints.
    /// </summary>
    public class BankStatementClient : BaseClient,
        IEntityDetail<BankStatementDetail>,
        IEntityList<BankStatementList>,
        IDeleteRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public BankStatementClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/BankStatements";

        /// <inheritdoc/>
        public BankStatementDetail Detail(int id)
        {
            return new BankStatementDetail(id, this);
        }

        /// <inheritdoc/>
        public BankStatementList List()
        {
            return new BankStatementList(this);
        }

        /// <summary>
        /// Pairs a model with an invoice according to the variable symbol and currency.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing pairing result.</returns>
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
