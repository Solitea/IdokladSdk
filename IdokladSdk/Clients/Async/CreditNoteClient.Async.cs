using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.CreditNote.Put;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class CreditNoteClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<CreditNotePostModel>> DefaultAsync(int id, CancellationToken cancellationToken = default)
        {
            return DefaultAsync<CreditNotePostModel>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <summary>
        /// Creates new credit note and offsets it with invoice. Credit note should contain only items with ItemTypeNormal.
        /// </summary>
        /// <param name="model">Credit note to be created.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{CreditNoteGetModel}"/> instance.</returns>
        public Task<ApiResult<CreditNoteGetModel>> OffsetAsync(CreditNotePostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Offset";
            return PostAsync<CreditNotePostModel, CreditNoteGetModel>(resource, model, cancellationToken);
        }

        /// <summary>
        /// Offsets existing credit note with issued invoice.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="model">Credit note offset parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{CreditNoteGetModel}"/> instance.</returns>
        public Task<ApiResult<CreditNoteGetModel>> OffsetAsync(int id, CreditNoteOffsetPutModel model = null, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Offset";
            return PutAsync<CreditNoteOffsetPutModel, CreditNoteGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<CreditNoteGetModel>> PostAsync(CreditNotePostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<CreditNotePostModel, CreditNoteGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<CreditNoteRecountGetModel>> RecountAsync(CreditNoteRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<CreditNoteRecountPostModel, CreditNoteRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<CreditNoteGetModel>> UpdateAsync(CreditNotePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<CreditNotePatchModel, CreditNoteGetModel>(model, cancellationToken);
        }
    }
}
