using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk.Clients
{
    public partial class ProformaInvoiceClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<ProformaInvoiceCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<ProformaInvoiceCopyGetModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ProformaInvoicePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ProformaInvoicePostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ProformaInvoiceGetModel>> PostAsync(ProformaInvoicePostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ProformaInvoicePostModel, ProformaInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ProformaInvoiceRecountGetModel>> RecountAsync(ProformaInvoiceRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<ProformaInvoiceRecountPostModel, ProformaInvoiceRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ProformaInvoiceGetModel>> UpdateAsync(ProformaInvoicePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<ProformaInvoicePatchModel, ProformaInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc cref="GetInvoiceForAccount"/>
        public Task<ApiResult<IssuedInvoicePostModel>> GetInvoiceForAccountAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Account";
            return GetAsync<IssuedInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc cref="Account"/>
        public async Task<ApiResult<IssuedInvoiceGetModel>> AccountAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Account";
            var request = await CreateRequestAsync(resource, Method.PUT, cancellationToken).ConfigureAwait(false);
            return await ExecuteAsync<IssuedInvoiceGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="AccountMultipleProformaInvoices"/>>
        public async Task<ApiResult<IssuedInvoiceGetModel>> AccountMultipleProformaInvoicesAsync(
            AccountProformaInvoicesPutModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Account";
            return await PutAsync<AccountProformaInvoicesPutModel, IssuedInvoiceGetModel>(resource, model, cancellationToken).ConfigureAwait(false);
        }
    }
}
