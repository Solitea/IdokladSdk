using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Models.IssuedTaxDocument.Post;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class IssuedTaxDocumentClient
    {
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
