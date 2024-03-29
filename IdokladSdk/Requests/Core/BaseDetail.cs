﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Requests.Core.Modifiers.Select.Common;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core
{
    /// <summary>
    /// Base class for detail requests without entity Id.
    /// </summary>
    /// <typeparam name="TDetail">Detail type.</typeparam>
    /// <typeparam name="TClient">Client type.</typeparam>
    /// <typeparam name="TGetModel">GetModel type.</typeparam>
    public abstract class BaseDetail<TDetail, TClient, TGetModel> : IGetDetailRequest<TGetModel>
        where TDetail : BaseDetail<TDetail, TClient, TGetModel>
        where TClient : BaseClient
        where TGetModel : new()
    {
        private readonly SelectModifier<TGetModel> _select = new SelectModifier<TGetModel>();

       /// <summary>
        /// Initializes a new instance of the <see cref="BaseDetail{TDetail, TClient, TGetModel}"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        protected BaseDetail(TClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Gets client.
        /// </summary>
        protected TClient Client { get; }

        /// <summary>
        /// Gets URL part for detail.
        /// </summary>
        /// <remarks>
        /// Can be null or empty string.
        /// </remarks>
        protected virtual string DetailName => string.Empty;

        /// <summary>
        /// Gets URL for detail.
        /// </summary>
        protected string ResourceUrl => string.IsNullOrEmpty(DetailName) ? Client.ResourceUrl : $"{Client.ResourceUrl}/{DetailName}";

        /// <summary>
        /// Gets reference to current instance which is of <typeparamref name="TDetail"/> name.
        /// </summary>
        protected TDetail This => this as TDetail;

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

        /// <summary>
        /// Get entity.
        /// </summary>
        /// <typeparam name="TResult">Result type.</typeparam>
        /// <param name="queryParams">Query params.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TResult}"/> instance.</returns>
        protected virtual Task<ApiResult<TResult>> GetCoreAsync<TResult>(Dictionary<string, string> queryParams, CancellationToken cancellationToken)
            where TResult : new()
        {
            return Client.GetAsync<TResult>(ResourceUrl, queryParams, cancellationToken);
        }

        /// <summary>
        /// Calls selector function to transform GET model to custom type.
        /// </summary>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <param name="apiResult">API result.</param>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <returns><see cref="ApiResult{TResult}"/> instance.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Called internally with not null parameters.")]
        protected ApiResult<TResult> ApplySelectorFunction<TResult>(ApiResult<TGetModel> apiResult, Expression<Func<TGetModel, TResult>> selector)
        {
            var selectorFunction = selector.Compile();
            var result = new ApiResult<TResult>
            {
                Data = apiResult.Data != null ? selectorFunction.Invoke(apiResult.Data) : default(TResult),
                ErrorCode = apiResult.ErrorCode,
                IsSuccess = apiResult.IsSuccess,
                Message = apiResult.Message,
                StatusCode = apiResult.StatusCode
            };

            return result;
        }

        /// <summary>
        /// Returns query parameters for request.
        /// </summary>
        /// <returns>Dictionary containing query parameters.</returns>
        protected virtual Dictionary<string, string> GetQueryParams()
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.AddRange(_select.GetQueryParameters());

            return queryParams;
        }
    }
}
