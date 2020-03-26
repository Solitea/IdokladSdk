using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for filtering.
    /// </summary>
    /// <typeparam name="TList">Return type.</typeparam>
    /// <typeparam name="TFilter">Filter type.</typeparam>
    public interface IFilterable<out TList, out TFilter>
    {
        /// <summary>
        /// Filters a list.
        /// </summary>
        /// <param name="filters">Filter expressions.</param>
        /// <returns>List of models.</returns>
        TList Filter(params Func<TFilter, FilterExpression>[] filters);

        /// <summary>
        /// Filters a list.
        /// </summary>
        /// <param name="filterType">Filter type.</param>
        /// <returns>List of models.</returns>
        TList FilterType(FilterType filterType);
    }
}
