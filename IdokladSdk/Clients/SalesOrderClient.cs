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
    public partial class SalesOrderClient :
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
        public ApiResult<SalesOrderPostModel> Copy(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return Get<SalesOrderPostModel>(resource);
        }

        /// <inheritdoc/>
        public ApiResult<SalesOrderPostModel> Default()
        {
            return Default<SalesOrderPostModel>();
        }

        /// <inheritdoc/>
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        /// <returns>Method return issued invoice post model.</returns>
        public ApiResult<IssuedInvoicePostModel> GetIssuedInvoice(int salesOrderId)
        {
            var resource = $"{ResourceUrl}/{salesOrderId}/IssuedInvoice";
            return Get<IssuedInvoicePostModel>(resource);
        }

        /// <summary>
        /// Returns new proforma invoice created from given sales order.
        /// </summary>
        /// <param name="salesOrderId">Sales order id.</param>
        /// <returns>Method return proforma invoice post model.</returns>
        public ApiResult<ProformaInvoicePostModel> GetProformaInvoice(int salesOrderId)
        {
            var resource = $"{ResourceUrl}/{salesOrderId}/ProformaInvoice";
            return Get<ProformaInvoicePostModel>(resource);
        }

        /// <inheritdoc/>
        public SalesOrderList List()
        {
            return new SalesOrderList(this);
        }

        /// <inheritdoc/>
        public ApiResult<SalesOrderGetModel> Post(SalesOrderPostModel model)
        {
            return Post<SalesOrderPostModel, SalesOrderGetModel>(model);
        }

        /// <inheritdoc/>
        public ApiResult<SalesOrderRecountGetModel> Recount(SalesOrderRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<SalesOrderRecountPostModel, SalesOrderRecountGetModel>(resource, model);
        }

        /// <inheritdoc/>
        public ApiResult<SalesOrderGetModel> Update(SalesOrderPatchModel model)
        {
            return Patch<SalesOrderPatchModel, SalesOrderGetModel>(model);
        }
    }
}
