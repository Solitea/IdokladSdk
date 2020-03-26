using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core
{
    public abstract partial class BaseList<TList, TClient, TGetModel, TFilter, TSort>
    {
        /// <inheritdoc/>
        public Task<ApiResult<Page<TGetModel>>> GetAsync(CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParameters();

            return _client.GetAsync<Page<TGetModel>>(ResourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<Page<TCustomResult>>> GetAsync<TCustomResult>(CancellationToken cancellationToken = default)
            where TCustomResult : new()
        {
            _select.Select<TCustomResult>();
            var queryParams = GetQueryParameters();

            return _client.GetAsync<Page<TCustomResult>>(ResourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ApiResult<Page<TResult>>> GetAsync<TResult>(Expression<Func<TGetModel, TResult>> selector, CancellationToken cancellationToken = default)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            _select.Select(selector);
            var queryParams = GetQueryParameters();
            var apiResult = await _client.GetAsync<Page<TGetModel>>(ResourceUrl, queryParams, cancellationToken).ConfigureAwait(false);
            return ApplySelectorFunction(apiResult, selector);
        }
    }
}
