using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Requests.CashVoucher;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with cash voucher endpoints.
    /// </summary>
    public partial class CashVoucherClient :
        BaseClient,
        IDeleteRequest,
        IEntityDetail<CashVoucherDetail>,
        IEntityList<CashVoucherList>,
        IPatchRequest<CashVoucherPatchModel, CashVoucherGetModel>,
        IPostRequest<CashVoucherPostModel, CashVoucherGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherClient"/> class.
        /// </summary>
        /// <param name="context">API context.</param>
        public CashVoucherClient(ApiContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl => "/CashVouchers";

        /// <inheritdoc cref="IDefaultRequest{TPostModel}.Default"/>
        /// <param name="movementType">Movement type.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherPostModel"/>.</returns>
        public ApiResult<CashVoucherPostModel> Default(MovementType movementType)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}";
            var request = CreateRequest(resource, Method.GET);

            return Execute<CashVoucherPostModel>(request);
        }

        /// <inheritdoc cref="IDefaultRequest{TPostModel}.Default"/>
        /// <param name="movementType">Movement type.</param>
        /// <param name="invoiceType">Invoice type.</param>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherPostModel"/>.</returns>
        public ApiResult<CashVoucherPostModel> Default(MovementType movementType, InvoiceType invoiceType, int invoiceId)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}/{invoiceType}/{invoiceId}";
            var request = CreateRequest(resource, Method.GET);

            return Execute<CashVoucherPostModel>(request);
        }

        /// <inheritdoc/>
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
        }

        /// <inheritdoc/>
        public CashVoucherDetail Detail(int id)
        {
            return new CashVoucherDetail(id, this);
        }

        /// <inheritdoc/>
        public CashVoucherList List()
        {
            return new CashVoucherList(this);
        }

        /// <summary>
        /// Pairs cash voucher with unpaid invoice.
        /// </summary>
        /// <param name="cashVoucherId">Id of cash voucher.</param>
        /// <param name="invoiceType">Invoice type.</param>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if pairing was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> Pair(int cashVoucherId, InvoiceType invoiceType, int invoiceId)
        {
            var resource = $"{ResourceUrl}/Pair/{cashVoucherId}/{invoiceType}/{invoiceId}";
            var request = CreateRequest(resource, Method.POST);

            return Execute<bool>(request);
        }

        /// <inheritdoc/>
        public ApiResult<CashVoucherGetModel> Post(CashVoucherPostModel model)
        {
            return Post<CashVoucherPostModel, CashVoucherGetModel>(model);
        }

        /// <inheritdoc/>
        public ApiResult<CashVoucherGetModel> Update(CashVoucherPatchModel model)
        {
            return Patch<CashVoucherPatchModel, CashVoucherGetModel>(model);
        }
    }
}
