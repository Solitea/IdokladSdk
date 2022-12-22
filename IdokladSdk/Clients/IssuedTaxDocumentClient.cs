using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Models.IssuedTaxDocument.Post;
using IdokladSdk.Requests.IssuedTaxDocument;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// IssuedTaxDocumentClient.
    /// </summary>
    public class IssuedTaxDocumentClient :
        BaseClient,
        IDefaultWithIdRequest<IssuedTaxDocumentGetModel>,
        IEntityDetail<IssuedTaxDocumentDetail>,
        IEntityList<IssuedTaxDocumentList>,
        IDeleteRequest,
        IPatchRequest<IssuedTaxDocumentPatchModel, IssuedTaxDocumentGetModel>,
        IPostRequest<IssuedTaxDocumentPostModel, IssuedTaxDocumentGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedTaxDocumentClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public IssuedTaxDocumentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/IssuedTaxDocuments";

        /// <inheritdoc />
        public Task<ApiResult<IssuedTaxDocumentGetModel>> DefaultAsync(int id, CancellationToken cancellationToken = default)
        {
            return DefaultAsync<IssuedTaxDocumentGetModel>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public IssuedTaxDocumentDetail Detail(int id)
        {
            return new IssuedTaxDocumentDetail(id, this);
        }

        /// <inheritdoc/>
        public IssuedTaxDocumentList List()
        {
            return new IssuedTaxDocumentList(this);
        }

        /// <summary>
        /// Asynchronously creates new issued tax document from proforma payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>New issued tax document.</returns>
        public Task<ApiResult<IssuedTaxDocumentGetModel>> PostAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}";
            return PostAsync<IssuedTaxDocumentGetModel>(resource, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedTaxDocumentGetModel>> PostAsync(IssuedTaxDocumentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<IssuedTaxDocumentPostModel, IssuedTaxDocumentGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedTaxDocumentGetModel>> UpdateAsync(IssuedTaxDocumentPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<IssuedTaxDocumentPatchModel, IssuedTaxDocumentGetModel>(model, cancellationToken);
        }
    }
}
