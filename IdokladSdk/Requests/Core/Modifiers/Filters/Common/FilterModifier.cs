using System;
using System.Collections.Generic;
using IdokladSdk.Requests.Core.Interfaces;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Query string filter modifier.
    /// </summary>
    /// <typeparam name="TFilter">Filter type.</typeparam>
    public class FilterModifier<TFilter> : IQueryStringModifier
        where TFilter : new()
    {
        private FilterExpression _singleFilter = null;
        private ComplexFilterExpression _complexFilter = null;

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
                AddSingleFilter(simpleFilter);
            }
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            string filter = null;

            if (_complexFilter != null)
            {
                filter = _complexFilter.ToString();
            }
            else if (_singleFilter != null)
            {
                filter = _singleFilter.ToString();
            }

            return GetFilterAsQueryParameter(filter);
        }

        private void AddComplexFilter(ComplexFilterExpression complexFilter)
        {
            if (_complexFilter != null)
            {
                _complexFilter = new ComplexFilterExpression
                {
                    FirstExpression = _complexFilter,
                    SecondExpression = complexFilter,
                    LogicalOperator = FilterType.And,
                };
            }
            else if (_singleFilter != null)
            {
                _complexFilter = new ComplexFilterExpression
                {
                    FirstExpression = _singleFilter,
                    SecondExpression = complexFilter,
                    LogicalOperator = FilterType.And,
                };
                _singleFilter = null;
            }
            else
            {
                _complexFilter = complexFilter;
            }
        }

        private void AddSingleFilter(FilterExpression singleFilter)
        {
            if (_singleFilter != null)
            {
                _complexFilter = new ComplexFilterExpression
                {
                    FirstExpression = _singleFilter,
                    SecondExpression = singleFilter,
                    LogicalOperator = FilterType.And,
                };
                _singleFilter = null;
            }
            else if (_complexFilter != null)
            {
                _complexFilter = new ComplexFilterExpression
                {
                    FirstExpression = _complexFilter,
                    SecondExpression = singleFilter,
                    LogicalOperator = FilterType.And,
                };
            }
            else
            {
                _singleFilter = singleFilter;
            }
        }

        private Dictionary<string, string> GetFilterAsQueryParameter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return null;
            }

            return new Dictionary<string, string>()
            {
                { "filter", filter },
            };
        }
    }
}
