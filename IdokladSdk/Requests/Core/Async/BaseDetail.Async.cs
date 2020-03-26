using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core
{
    public abstract partial class BaseDetail<TDetail, TClient, TGetModel>
    {
        /// <inheritdoc/>
        public Task<ApiResult<TGetModel>> GetAsync(CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParams();
            return GetCoreAsync<TGetModel>(queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<TCustomModel>> GetAsync<TCustomModel>(CancellationToken cancellationToken = default)
            where TCustomModel : new()
        {
            _select.Select<TCustomModel>();
            var queryParams = GetQueryParams();
            return GetCoreAsync<TCustomModel>(queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ApiResult<TResult>> GetAsync<TResult>(Expression<Func<TGetModel, TResult>> selector, CancellationToken cancellationToken = default)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            _select.Select(selector);
            var queryParams = GetQueryParams();
            var apiResult = await GetCoreAsync<TGetModel>(queryParams, cancellationToken).ConfigureAwait(false);
            return ApplySelectorFunction(apiResult, selector);
        }

        /// <inheritdoc cref="GetCore{TResult}"/>
        protected virtual Task<ApiResult<TResult>> GetCoreAsync<TResult>(Dictionary<string, string> queryParams, CancellationToken cancellationToken)
            where TResult : new()
        {
            return Client.GetAsync<TResult>(ResourceUrl, queryParams, cancellationToken);
        }
    }
}
