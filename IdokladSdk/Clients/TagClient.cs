using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Tag;
using IdokladSdk.Requests.Tag;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// TagClient.
    /// </summary>
    public class TagClient : BaseClient,
        IDeleteRequest,
        IEntityList<TagList>,
        IPatchRequest<TagPatchModel, TagGetModel>,
        IPostRequest<TagPostModel, TagGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public TagClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Tags";

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public TagList List()
        {
            return new TagList(this);
        }

        /// <inheritdoc />
        public Task<ApiResult<TagGetModel>> PostAsync(TagPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<TagPostModel, TagGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<TagGetModel>> UpdateAsync(TagPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<TagPatchModel, TagGetModel>(model, cancellationToken);
        }
    }
}
