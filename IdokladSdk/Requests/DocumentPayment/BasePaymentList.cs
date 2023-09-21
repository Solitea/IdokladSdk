using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Requests.Core;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.DocumentPayment
{
    /// <summary>
    /// BaseReportList.
    /// </summary>
    /// <typeparam name="TList">List type.</typeparam>
    /// <typeparam name="TClient">Client type.</typeparam>
    /// <typeparam name="TGetModel">GetModel type.</typeparam>
    /// <typeparam name="TFilter">Filter type.</typeparam>
    /// <typeparam name="TSort">Sort type.</typeparam>
    public abstract class BasePaymentList<TList, TClient, TGetModel, TFilter, TSort> 
        : BaseListCore<TList, TClient, TGetModel, TFilter, TSort>
        where TList : BasePaymentList<TList, TClient, TGetModel, TFilter, TSort>
        where TClient : BaseClient
        where TFilter : new()
        where TSort : new()
        where TGetModel : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePaymentList{TList, TClient, TGetModel, TFilter, TSort}" /> class.
        /// </summary>
        /// <param name="client">Client.</param>
        protected BasePaymentList(TClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Retrieves a list of entities.
        /// </summary>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        protected Task<ApiResult<Page<TGetModel>>> GetAsync(string type, CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            return Client.GetAsync<Page<TGetModel>>(resourceUrl, queryParams, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of entities mapped to custom type.
        /// </summary>
        /// <param name="type">Payment document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TCustomModel">Custom model type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        protected Task<ApiResult<Page<TCustomModel>>> GetAsync<TCustomModel>(string type, CancellationToken cancellationToken = default)
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
        protected async Task<ApiResult<Page<TResult>>> GetAsync<TResult>(
            Expression<Func<TGetModel, TResult>> selector, string type, CancellationToken cancellationToken = default)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            Select.Select(selector);
            var queryParams = GetQueryParameters();
            var resourceUrl = $"{ResourceUrl}/Get/{type}";
            var apiResult = await Client.GetAsync<Page<TGetModel>>(resourceUrl, queryParams, cancellationToken)
                .ConfigureAwait(false);
            return ApplySelectorFunction(apiResult, selector);
        }
    }
}
