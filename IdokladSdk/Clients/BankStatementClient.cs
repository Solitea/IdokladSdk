using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.BankStatement.Get;
using IdokladSdk.Models.BankStatement.Pair;
using IdokladSdk.Models.BankStatement.Patch;
using IdokladSdk.Models.BankStatement.Post;
using IdokladSdk.Models.BankStatement.Recount;
using IdokladSdk.Models.Common.PairedDocument;
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
        IPostRequest<BankStatementPostModel, BankStatementGetModel>,
        IPatchRequest<BankStatementPatchModel, BankStatementGetModel>,
        IRecountRequest<BankStatementRecountPostModel, BankStatementRecountGetModel>,
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

        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="movementType">Movement type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="BankStatementDefaultGetModel"/>.</returns>
        public async Task<ApiResult<BankStatementDefaultGetModel>> DefaultAsync(MovementType movementType, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}";
            var request = await CreateRequestAsync(resource, HttpMethod.Get, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<BankStatementDefaultGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentId">Id of document.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="BankStatementDefaultGetModel"/>.</returns>
        public async Task<ApiResult<BankStatementDefaultGetModel>> DefaultAsync(PairedDocumentType documentType, int documentId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{documentType}/{documentId}";
            var request = await CreateRequestAsync(resource, HttpMethod.Get, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<BankStatementDefaultGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, default);
        }

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
        /// Bank mail notifications.
        /// </summary>
        /// <param name="previousNotificationId">Previous notification id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return bank mail notifications.</returns>
        public Task<ApiResult<List<BankMailNotificationHistoryGetModel>>> NotificationsAsync(
            long? previousNotificationId = null,
            CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/BankMailHistory";
            var queryParams =
                new Dictionary<string, string> { { "previousNotificationId", previousNotificationId.ToString() } };
            return GetAsync<List<BankMailNotificationHistoryGetModel>>(resource, queryParams, cancellationToken);
        }

        /// <summary>
        /// Pairs a model with a document according to the variable symbol and currency.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing pairing result.</returns>
        public Task<ApiResult<BankStatementPairingResult>> PairAsync(
            BankStatementPairingPostModel model,
            CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Pair";
            return PostAsync<BankStatementPairingPostModel, BankStatementPairingResult>(resource, model, cancellationToken);
        }

        /// <summary>
        /// Pairs a model with a document according to the document type and document id.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing pairing result.</returns>
        public Task<ApiResult<bool>> PairWithDocumentAsync(
            BankStatementPairDocumentPostModel model,
            CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/PairWithDocument";
            return PostAsync<BankStatementPairDocumentPostModel, bool>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<BankStatementGetModel>> PostAsync(BankStatementPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<BankStatementPostModel, BankStatementGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<BankStatementGetModel>> UpdateAsync(BankStatementPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<BankStatementPatchModel, BankStatementGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<BankStatementRecountGetModel>> RecountAsync(BankStatementRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<BankStatementRecountPostModel, BankStatementRecountGetModel>(resource, model, cancellationToken);
        }
    }
}
