using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core
{
    /// <summary>
    /// Base class for list requests.
    /// </summary>
    /// <typeparam name="TList">List type.</typeparam>
    /// <typeparam name="TClient">Client type.</typeparam>
    /// <typeparam name="TGetModel">GetModel type.</typeparam>
    /// <typeparam name="TFilter">Filter type.</typeparam>
    /// <typeparam name="TSort">Sort type.</typeparam>
    public abstract class BaseList<TList, TClient, TGetModel, TFilter, TSort> : BaseListCore<TList, TClient, TGetModel, TFilter, TSort> ,IGetListRequest<TGetModel>
        where TList : BaseList<TList, TClient, TGetModel, TFilter, TSort>
        where TClient : BaseClient
        where TFilter : new()
        where TSort : new()
        where TGetModel : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseList{TList, TClient, TGetModel, TFilter, TSort}" /> class.
        /// </summary>
        /// <param name="client">Client type.</param>
        protected BaseList(TClient client) 
            : base(client)
        {
        }

        /// <inheritdoc />
        public Task<ApiResult<Page<TGetModel>>> GetAsync(CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParameters();

            return Client.GetAsync<Page<TGetModel>>(ResourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<Page<TCustomResult>>> GetAsync<TCustomResult>(CancellationToken cancellationToken = default)
            where TCustomResult : new()
        {
            Select.Select<TCustomResult>();
            var queryParams = GetQueryParameters();

            return Client.GetAsync<Page<TCustomResult>>(ResourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ApiResult<Page<TResult>>> GetAsync<TResult>(Expression<Func<TGetModel, TResult>> selector, CancellationToken cancellationToken = default)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            Select.Select(selector);
            var queryParams = GetQueryParameters();
            var apiResult = await Client.GetAsync<Page<TGetModel>>(ResourceUrl, queryParams, cancellationToken).ConfigureAwait(false);
            return ApplySelectorFunction(apiResult, selector);
        }
    }
}
