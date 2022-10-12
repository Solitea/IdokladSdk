using System;
using System.Collections.Generic;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report
{
    /// <summary>
    /// BaseReportList.
    /// </summary>
    /// <typeparam name="TList">List type.</typeparam>
    /// <typeparam name="TClient">Client type.</typeparam>
    /// <typeparam name="TGetModel">GetModel type.</typeparam>
    /// <typeparam name="TFilter">Filter type.</typeparam>
    /// <typeparam name="TSort">Sort type.</typeparam>
    public abstract partial class BaseReportList<TList, TClient, TGetModel, TFilter, TSort>
        where TList : BaseReportList<TList, TClient, TGetModel, TFilter, TSort>
        where TClient : BaseClient
        where TFilter : new()
        where TSort : new()
    {
        private readonly TClient _client;
        private readonly ReportDocumentType _documentType;

        private readonly FilterModifier<TFilter> _filter = new FilterModifier<TFilter>();

        private readonly SortModifier<TSort> _sort = new SortModifier<TSort>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReportList{TList, TClient, TGetModel, TFilter, TSort}"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        protected BaseReportList(TClient client, ReportDocumentType documentType)
        {
            _client = client;
            _documentType = documentType;
        }

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
        /// Filter type for a list.
        /// </summary>
        /// <param name="filterType">Filter type.</param>
        /// <returns>List of models.</returns>
        public TList FilterType(FilterType filterType)
        {
            _filter.FilterType(filterType);
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
        /// Call Get endpoint.
        /// </summary>
        /// <param name="language">Language.</param>
        /// <returns>API result.</returns>
        public ApiResult<TGetModel> Get(Language language)
        {
            var queryParams = GetQueryParameters();
            var resource = $"{_client.ResourceUrl}{_documentType}/Pdf/List/{language}";
            return _client.Get<TGetModel>(resource, queryParams);
        }

        /// <summary>
        /// Call Get endpoint.
        /// </summary>
        /// <param name="options">Options.</param>
        /// <returns>API result.</returns>
        public ApiResult<List<ReportImageGetModel>> GetImage(ReportImageOption options)
        {
            var queryParams = GetQueryParameters();
            if (options.Language != null)
            {
                queryParams.Add("language", options.Language.ToString());
            }

            if (options.Resolution != null)
            {
                queryParams.Add("resolution", options.Resolution.ToString());
            }

            var resource = $"{_client.ResourceUrl}{_documentType}/Image/List/";
            return _client.Get<List<ReportImageGetModel>>(resource, queryParams);
        }

        /// <summary>
        /// Get query parameters.
        /// </summary>
        /// <returns>Dictionary of query parameters.</returns>
        protected Dictionary<string, string> GetQueryParameters()
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.AddRange(_filter.GetQueryParameters());
            queryParams.AddRange(_sort.GetQueryParameters());

            return queryParams;
        }
    }
}
