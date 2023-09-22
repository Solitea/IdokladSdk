using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.DocumentPayment.Sales.Filter;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.DocumentPayment.Sales
{
    /// <summary>
    /// SalesDocumentPaymentList.
    /// </summary>
    public class SalesDocumentPaymentList : BaseListCore<SalesDocumentPaymentList, DocumentPaymentClient,
        SalesDocumentPaymentListGetModel, SalesPaymentFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesDocumentPaymentList" /> class.
        /// </summary>
        /// <param name="client">Document payment client.</param>
        public SalesDocumentPaymentList(DocumentPaymentClient client)
            : base(client)
        {
        }

        /// <inheritdoc />
        protected override string ListName { get; set; } = "Sales";

        /// <summary>
        /// Retrieves a list of entities.
        /// </summary>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public Task<ApiResult<Page<SalesDocumentPaymentListGetModel>>> GetAsync(
            DocumentPaymentSalesType type = DocumentPaymentSalesType.All,
            CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            return Client.GetAsync<Page<SalesDocumentPaymentListGetModel>>(resourceUrl, queryParams, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of entities mapped to custom type.
        /// </summary>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TCustomModel">Custom model type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public Task<ApiResult<Page<TCustomModel>>> GetAsync<TCustomModel>(
            DocumentPaymentSalesType type = DocumentPaymentSalesType.All,
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
            Expression<Func<SalesDocumentPaymentListGetModel, TResult>> selector,
            DocumentPaymentSalesType type = DocumentPaymentSalesType.All,
            CancellationToken cancellationToken = default)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            Select.Select(selector);
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            var apiResult = await Client.GetAsync<Page<SalesDocumentPaymentListGetModel>>(resourceUrl, queryParams, cancellationToken)
                .ConfigureAwait(false);
            return ApplySelectorFunction(apiResult, selector);
        }
    }
}
