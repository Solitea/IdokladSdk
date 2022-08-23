using System;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesOrderPostModel> Copy(int id)
        {
            return CopyAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesOrderPostModel> Default()
        {
            return DefaultAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoicePostModel> GetIssuedInvoice(int salesOrderId)
        {
            return GetIssuedInvoiceAsync(salesOrderId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns new proforma invoice created from given sales order.
        /// </summary>
        /// <param name="salesOrderId">Sales order id.</param>
        /// <returns>Method return proforma invoice post model.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<ProformaInvoicePostModel> GetProformaInvoice(int salesOrderId)
        {
            return GetProformaInvoiceAsync(salesOrderId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public SalesOrderList List()
        {
            return new SalesOrderList(this);
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesOrderGetModel> Post(SalesOrderPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesOrderRecountGetModel> Recount(SalesOrderRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesOrderGetModel> Update(SalesOrderPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
