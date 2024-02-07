using System;
using System.Collections.Generic;
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
            if (_singleFilter != null)
            {
                throw new InvalidOperationException("Single item filter has already been used, cannot add complex filter expression.");
            }

            if (_complexFilter != null)
            {
                throw new InvalidOperationException("Only single complex expression is allowed.");
            }

            _complexFilter = complexFilter;
        }

        private void AddSingleFilter(FilterExpression simpleFilter)
        {
            CheckExistingComplexFilter();

            if (_singleFilter != null)
            {
                throw new InvalidOperationException("Multiple single filters are not allowed, they need to be chained together.");
            }

            _singleFilter = simpleFilter;
        }

        private void CheckExistingComplexFilter()
        {
            if (_complexFilter != null)
            {
                throw new InvalidOperationException("Complex filter expression has already been used, cannot add another expression filters.");
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
