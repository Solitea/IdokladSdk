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
        private readonly HashSet<FilterExpression> _simpleFilters = new HashSet<FilterExpression>();

        private ComplexFilterExpression _complexFilter = null;

        private FilterType? _filterType = null;

        /// <summary>
        /// Add filter.
        /// </summary>
        /// <param name="filters">Filters.</param>
        public void Filter(params Func<TFilter, FilterExpression>[] filters)
        {
            CheckExistingComplexFilter();

            var filterableObject = new TFilter();

            foreach (var filter in filters)
            {
                var simpleFilter = filter.Invoke(filterableObject);
                _simpleFilters.Add(simpleFilter);
            }
        }

        /// <summary>
        /// Add filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        public void Filter(Func<TFilter, FilterExpressionBase> filter)
        {
            _ = filter ?? throw new ArgumentNullException(nameof(filter));

            var filterableObject = new TFilter();
            var filterExpression = filter.Invoke(filterableObject);

            if (filterExpression is ComplexFilterExpression complexFilter)
            {
                AddComplexFilter(complexFilter);
            }
            else if (filterExpression is FilterExpression simpleFilter)
            {
                AddSimpleFilter(simpleFilter);
            }
        }

        /// <summary>
        /// Set filter type.
        /// </summary>
        /// <param name="filterType">Filter type.</param>
        public void FilterType(FilterType filterType)
        {
            if (_complexFilter != null)
            {
                throw new InvalidOperationException("Cannot specify filter type when complex filter expression is used.");
            }

            _filterType = filterType;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            if (_complexFilter != null)
            {
                return GetQueryParametersComplexFilter();
            }
            else if (_simpleFilters.Any())
            {
                return GetQueryParametersSimpleFilters();
            }

            return null;
        }

        private void AddComplexFilter(ComplexFilterExpression complexFilter)
        {
            if (_simpleFilters.Any())
            {
                throw new InvalidOperationException("Individual item filters have already been used, cannot add complex filter expression.");
            }

            if (_complexFilter != null)
            {
                throw new InvalidOperationException("Only single complex expression is allowed.");
            }

            if (_filterType.HasValue)
            {
                throw new InvalidOperationException($"Complex filter expression cannot be used together with {nameof(FilterType)} method.");
            }

            _complexFilter = complexFilter;
        }

        private void AddSimpleFilter(FilterExpression simpleFilter)
        {
            CheckExistingComplexFilter();
            _simpleFilters.Add(simpleFilter);
        }

        private void CheckExistingComplexFilter()
        {
            if (_complexFilter != null)
            {
                throw new InvalidOperationException("Complex filter expression has already been used, cannot add another expression filters.");
            }
        }

        private Dictionary<string, string> GetQueryParametersComplexFilter()
        {
            var filter = _complexFilter.ToString();

            return new Dictionary<string, string>()
            {
                { "filter", filter },
            };
        }

        private Dictionary<string, string> GetQueryParametersSimpleFilters()
        {
            var filter = string.Join("|", _simpleFilters);
            var filterType = _filterType ?? Common.FilterType.And;
            var filterTypeStr = filterType.ToString().ToLower(CultureInfo.InvariantCulture);

            return new Dictionary<string, string>()
            {
                { "filter", filter },
                { "filterType", filterTypeStr }
            };
        }
    }
}
