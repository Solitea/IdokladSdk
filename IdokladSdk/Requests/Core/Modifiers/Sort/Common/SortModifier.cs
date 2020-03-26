using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Requests.Core.Interfaces;

namespace IdokladSdk.Requests.Core.Modifiers.Sort.Common
{
    /// <summary>
    /// Sort query string modifier.
    /// </summary>
    /// <typeparam name="TSort">Sort type.</typeparam>
    public class SortModifier<TSort> : IQueryStringModifier
        where TSort : new()
    {
        private readonly HashSet<SortExpression> _sort = new HashSet<SortExpression>();

        /// <summary>
        /// Add sort to request.
        /// </summary>
        /// <param name="sorts">Sort expressions.</param>
        public void Sort(params Func<TSort, SortExpression>[] sorts)
        {
            var sortableObject = new TSort();

            foreach (var sort in sorts)
            {
                var sortExpression = sort.Invoke(sortableObject);
                if (_sort.Any(s => s.PropertyName == sortExpression.PropertyName))
                {
                    throw new ApplicationException($"Sort for {sortExpression.PropertyName} is already defined");
                }

                _sort.Add(sortExpression);
            }
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            if (!_sort.Any())
            {
                return null;
            }

            return new Dictionary<string, string>
            {
                { "sort", string.Join("|", _sort) }
            };
        }
    }
}
