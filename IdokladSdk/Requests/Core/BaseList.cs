using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IdokladSdk.Clients;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using IdokladSdk.Requests.Core.Modifiers.Page;
using IdokladSdk.Requests.Core.Modifiers.Select.Common;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;
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
    public abstract partial class BaseList<TList, TClient, TGetModel, TFilter, TSort> : IGetListRequest<TGetModel>,
        IFilterable<TList, TFilter>, ISortable<TList, TSort>, IPageable<TList>
        where TList : BaseList<TList, TClient, TGetModel, TFilter, TSort>
        where TClient : BaseClient
        where TFilter : new()
        where TSort : new()
        where TGetModel : new()
    {
        private readonly TClient _client;

        private readonly FilterModifier<TFilter> _filter = new FilterModifier<TFilter>();

        private readonly PageModifier _page = new PageModifier();

        private readonly SelectModifier<TGetModel> _select = new SelectModifier<TGetModel>();

        private readonly SortModifier<TSort> _sort = new SortModifier<TSort>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseList{TList, TClient, TGetModel, TFilter, TSort}" /> class.
        /// </summary>
        /// <param name="client">Client type.</param>
        public BaseList(TClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets or sets URL part for list.
        /// </summary>
        /// <remarks>
        /// Can be null or empty string.
        /// </remarks>
        protected virtual string ListName { get; set; } = string.Empty;

        /// <summary>
        /// Gets URL for detail.
        /// </summary>
        protected string ResourceUrl =>
            string.IsNullOrEmpty(ListName) ? _client.ResourceUrl : $"{_client.ResourceUrl}/{ListName}";

        private TList This => this as TList;

        /// <summary>
        /// Filter for a list.
        /// </summary>
        /// <param name="filter">Filter expressions.</param>
        /// <returns>List of models.</returns>
        public TList Filter(params Func<TFilter, FilterExpression>[] filter)
        {
            _filter.Filter(filter);
            return This;
        }

        /// <summary>
        /// Filter for a list.
        /// </summary>
        /// <param name="filter">Filter expressions.</param>
        /// <returns>List of models.</returns>
        public TList Filter(Func<TFilter, FilterExpressionBase> filter)
        {
            _filter.Filter(filter);
            return This;
        }

        /// <summary>
        /// Filter type for a list.
        /// </summary>
        /// <param name="filterType">Filter type.</param>
        /// <returns>List of models.</returns>
        public TList FilterType(FilterType filterType)
        {
            _filter.FilterType(filterType);
            return This;
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<Page<TGetModel>> Get()
        {
            return GetAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<Page<TCustomResult>> Get<TCustomResult>()
            where TCustomResult : new()
        {
            return GetAsync<TCustomResult>().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public virtual ApiResult<Page<TResult>> Get<TResult>(Expression<Func<TGetModel, TResult>> selector)
        {
            return GetAsync<TResult>(selector).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get specified page of a list.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <returns>List of models.</returns>
        public TList Page(int page = Constants.DefaultPage)
        {
            _page.Page = page;
            return This;
        }

        /// <summary>
        /// Set page size.
        /// </summary>
        /// <param name="pageSize">Page size (default 20).</param>
        /// <returns>List of models.</returns>
        public TList PageSize(int pageSize = Constants.DefaultPageSize)
        {
            _page.PageSize = pageSize;
            return This;
        }

        /// <summary>
        /// Sorting of a list.
        /// </summary>
        /// <param name="sort">Sort expressions.</param>
        /// <returns>List of models.</returns>
        public TList Sort(params Func<TSort, SortExpression>[] sort)
        {
            _sort.Sort(sort);
            return This;
        }

        /// <summary>
        /// Calls selector function to transform GET model to custom type.
        /// </summary>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <param name="apiResult">API result.</param>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <returns><see cref="ApiResult{TResult}"/> instance.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Called internally with not null parameters.")]
        protected ApiResult<Page<TResult>> ApplySelectorFunction<TResult>(ApiResult<Page<TGetModel>> apiResult, Expression<Func<TGetModel, TResult>> selector)
        {
            var selectorFunction = selector.Compile();
            var result = new ApiResult<Page<TResult>>
            {
                Data = new Page<TResult>
                {
                    Items = apiResult.Data?.Items?.Select(o => selectorFunction.Invoke(o)),
                    TotalItems = apiResult.Data?.TotalItems ?? 0,
                    TotalPages = apiResult.Data?.TotalPages ?? 0
                },
                ErrorCode = apiResult.ErrorCode,
                IsSuccess = apiResult.IsSuccess,
                Message = apiResult.Message,
                StatusCode = apiResult.StatusCode
            };

            return result;
        }

        /// <summary>
        /// Get query parameters.
        /// </summary>
        /// <returns>Dictionary of query parameters.</returns>
        protected Dictionary<string, string> GetQueryParameters()
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.AddRange(_page.GetQueryParameters());
            queryParams.AddRange(_filter.GetQueryParameters());
            queryParams.AddRange(_sort.GetQueryParameters());
            queryParams.AddRange(_select.GetQueryParameters());

            return queryParams;
        }
    }
}
