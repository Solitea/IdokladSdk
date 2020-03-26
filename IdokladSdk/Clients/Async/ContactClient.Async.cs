using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Contact;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class ContactClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<ContactPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ContactPostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ContactGetModel>> PostAsync(ContactPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ContactPostModel, ContactGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ContactGetModel>> UpdateAsync(ContactPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<ContactPatchModel, ContactGetModel>(model, cancellationToken);
        }
    }
}
