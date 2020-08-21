using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class SalesOrderClient
    {
        /// <inheritdoc />
        public Task<ApiResult<SalesOrderPostModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<SalesOrderPostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesOrderPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<SalesOrderPostModel>(cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc cref="GetIssuedInvoice" />
        public Task<ApiResult<IssuedInvoicePostModel>> GetIssuedInvoiceAsync(int salesOrderId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{salesOrderId}/IssuedInvoice";
            return GetAsync<IssuedInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc cref="GetProformaInvoice" />
        public Task<ApiResult<ProformaInvoicePostModel>> GetProformaInvoiceAsync(int salesOrderId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{salesOrderId}/ProformaInvoice";
            return GetAsync<ProformaInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesOrderGetModel>> PostAsync(SalesOrderPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<SalesOrderPostModel, SalesOrderGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesOrderRecountGetModel>> RecountAsync(SalesOrderRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<SalesOrderRecountPostModel, SalesOrderRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesOrderGetModel>> UpdateAsync(SalesOrderPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<SalesOrderPatchModel, SalesOrderGetModel>(model, cancellationToken);
        }
    }
}
