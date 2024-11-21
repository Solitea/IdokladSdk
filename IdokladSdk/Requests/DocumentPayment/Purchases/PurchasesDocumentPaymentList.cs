using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Payment.DocumentPayments.Purchases.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.DocumentPayment.Purchases.Filter;
using IdokladSdk.Requests.DocumentPayment.Purchases.Sort;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.DocumentPayment.Purchases
{
    /// <summary>
    /// PurchasesDocumentPaymentList.
    /// </summary>
    public class PurchasesDocumentPaymentList : BaseListCore<PurchasesDocumentPaymentList, DocumentPaymentClient,
        PurchaseDocumentPaymentListGetModel, PurchasesPaymentFilter, PurchasesPaymentSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasesDocumentPaymentList" /> class.
        /// </summary>
        /// <param name="client">Document payment client.</param>
        public PurchasesDocumentPaymentList(DocumentPaymentClient client)
            : base(client)
        {
        }

        /// <inheritdoc />
        protected override string ListName { get; set; } = "Purchase";

        /// <summary>
        /// Retrieves a list of entities.
        /// </summary>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public Task<ApiResult<Page<PurchaseDocumentPaymentListGetModel>>> GetAsync(
            DocumentPaymentPurchaseType type = DocumentPaymentPurchaseType.All,
            CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            return Client.GetAsync<Page<PurchaseDocumentPaymentListGetModel>>(resourceUrl, queryParams, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of entities mapped to custom type.
        /// </summary>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TCustomModel">Custom model type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public Task<ApiResult<Page<TCustomModel>>> GetAsync<TCustomModel>(
            DocumentPaymentPurchaseType type = DocumentPaymentPurchaseType.All,
            CancellationToken cancellationToken = default)
            where TCustomModel : new()
        {
            Select.Select<TCustomModel>();
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            return Client.GetAsync<Page<TCustomModel>>(resourceUrl, queryParams, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of entities and transforms each entity to custom type by calling a transform function.
        /// </summary>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public async Task<ApiResult<Page<TResult>>> GetAsync<TResult>(
            Expression<Func<PurchaseDocumentPaymentListGetModel, TResult>> selector,
            DocumentPaymentPurchaseType type = DocumentPaymentPurchaseType.All,
            CancellationToken cancellationToken = default)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            Select.Select(selector);
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            var apiResult = await Client
                .GetAsync<Page<PurchaseDocumentPaymentListGetModel>>(resourceUrl, queryParams, cancellationToken)
                .ConfigureAwait(false);
            return ApplySelectorFunction(apiResult, selector);
        }
    }
}
