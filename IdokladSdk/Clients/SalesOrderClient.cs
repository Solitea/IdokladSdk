using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.SalesOrder;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with sales order endpoints.
    /// </summary>
    public class SalesOrderClient :
        BaseClient,
        ICopyRequest<SalesOrderPostModel>,
        IDeleteRequest,
        IEntityDetail<SalesOrderDetail>,
        IEntityList<SalesOrderList>,
        IDefaultRequest<SalesOrderPostModel>,
        IPatchRequest<SalesOrderPatchModel, SalesOrderGetModel>,
        IPostRequest<SalesOrderPostModel, SalesOrderGetModel>,
        IRecountRequest<SalesOrderRecountPostModel, SalesOrderRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public SalesOrderClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/SalesOrders";

        /// <inheritdoc />
        public Task<ApiResult<SalesOrderPostModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<SalesOrderPostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesOrderPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<SalesOrderPostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public SalesOrderDetail Detail(int id)
        {
            return new SalesOrderDetail(id, this);
        }

        /// <summary>
        /// Returns new issued invoice created from given sales order.
        /// </summary>
        /// <param name="salesOrderId">Sales order id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Method return issued invoice post model.</returns>
        public Task<ApiResult<IssuedInvoicePostModel>> GetIssuedInvoiceAsync(int salesOrderId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{salesOrderId}/IssuedInvoice";
            return GetAsync<IssuedInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <summary>
        /// Returns new proforma invoice created from given sales order.
        /// </summary>
        /// <param name="salesOrderId">Sales order id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Method return proforma invoice post model.</returns>
        public Task<ApiResult<ProformaInvoicePostModel>> GetProformaInvoiceAsync(int salesOrderId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{salesOrderId}/ProformaInvoice";
            return GetAsync<ProformaInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc/>
        public SalesOrderList List()
        {
            return new SalesOrderList(this);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesOrderGetModel>> PostAsync(SalesOrderPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<SalesOrderPostModel, SalesOrderGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesOrderRecountGetModel>> RecountAsync(SalesOrderRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<SalesOrderRecountPostModel, SalesOrderRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesOrderGetModel>> UpdateAsync(SalesOrderPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<SalesOrderPatchModel, SalesOrderGetModel>(model, cancellationToken);
        }
    }
}
