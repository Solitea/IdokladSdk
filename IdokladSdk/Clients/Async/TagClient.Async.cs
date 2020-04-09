using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Tag;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// TagClient.
    /// </summary>
    public partial class TagClient
    {
        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<TagGetModel>> UpdateAsync(TagPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<TagPatchModel, TagGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<TagGetModel>> PostAsync(TagPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<TagPostModel, TagGetModel>(model, cancellationToken);
        }
    }
}
