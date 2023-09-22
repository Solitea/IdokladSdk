using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedDocumentTemplate.Copy;
using IdokladSdk.Models.IssuedDocumentTemplate.Get;
using IdokladSdk.Models.IssuedDocumentTemplate.Patch;
using IdokladSdk.Models.IssuedDocumentTemplate.Post;
using IdokladSdk.Models.IssuedDocumentTemplate.Recount;
using IdokladSdk.Requests.IssuedDocumentTemplate;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with issued document template endpoints.
    /// </summary>
    public class IssuedDocumentTemplateClient : BaseClient,
        IDeleteRequest,
        IEntityDetail<IssuedDocumentTemplateDetail>,
        IEntityList<IssuedDocumentTemplateList>,
        IDefaultRequest<IssuedDocumentTemplatePostModel>,
        IPostRequest<IssuedDocumentTemplatePostModel, IssuedDocumentTemplateGetModel>,
        IPatchRequest<IssuedDocumentTemplatePatchModel, IssuedDocumentTemplateGetModel>,
        IRecountRequest<IssuedDocumentTemplateRecountPostModel, IssuedDocumentTemplateRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentTemplateClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public IssuedDocumentTemplateClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/IssuedDocumentTemplates";

        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentTemplatePostModel>> DefaultAsync(
            CancellationToken cancellationToken = default)
        {
            return DefaultAsync<IssuedDocumentTemplatePostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public IssuedDocumentTemplateDetail Detail(int id)
        {
            return new IssuedDocumentTemplateDetail(id, this);
        }

        /// <inheritdoc/>
        public IssuedDocumentTemplateList List()
        {
            return new IssuedDocumentTemplateList(this);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentTemplateGetModel>> PostAsync(
            IssuedDocumentTemplatePostModel model,
            CancellationToken cancellationToken = default)
        {
            return PostAsync<IssuedDocumentTemplatePostModel, IssuedDocumentTemplateGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentTemplateRecountGetModel>> RecountAsync(
            IssuedDocumentTemplateRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<IssuedDocumentTemplateRecountPostModel, IssuedDocumentTemplateRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentTemplateGetModel>> UpdateAsync(
            IssuedDocumentTemplatePatchModel model,
            CancellationToken cancellationToken = default)
        {
            return PatchAsync<IssuedDocumentTemplatePatchModel, IssuedDocumentTemplateGetModel>(model, cancellationToken);
        }

        /// <summary>
        /// Method returns copy of issued document template. Returned resource is suitable for new template creation.
        /// </summary>
        /// <param name="id">Template id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Resource of issued document template for creation.</returns>
        public Task<ApiResult<IssuedDocumentTemplateCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<IssuedDocumentTemplateCopyGetModel>(resource, null, cancellationToken);
        }
    }
}
