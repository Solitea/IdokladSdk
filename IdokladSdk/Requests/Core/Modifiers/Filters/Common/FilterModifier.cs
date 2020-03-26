using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using IdokladSdk.Requests.Core.Interfaces;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Qery string filter modifier.
    /// </summary>
    /// <typeparam name="TFilter">Filter type.</typeparam>
    public class FilterModifier<TFilter> : IQueryStringModifier
        where TFilter : new()
    {
        private readonly HashSet<FilterExpression> _filters = new HashSet<FilterExpression>();

        private FilterType _filterType = Common.FilterType.And;

        /// <summary>
        /// Add filter.
        /// </summary>
        /// <param name="filters">Filters.</param>
        public void Filter(params Func<TFilter, FilterExpression>[] filters)
        {
            var filterableObject = new TFilter();

            foreach (var filter in filters)
            {
                var filterExpression = filter.Invoke(filterableObject);
                _filters.Add(filterExpression);
            }
        }

        /// <summary>
        /// Set filter type.
        /// </summary>
        /// <param name="filterType">Tilter type.</param>
        public void FilterType(FilterType filterType)
        {
            _filterType = filterType;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            if (!_filters.Any())
            {
                return null;
            }

            var filter = string.Join("|", _filters);
            var filterType = _filterType.ToString().ToLower(CultureInfo.InvariantCulture);

            return new Dictionary<string, string>()
            {
                { "filter", filter },
                { "filterType", filterType }
            };
        }
    }
}
