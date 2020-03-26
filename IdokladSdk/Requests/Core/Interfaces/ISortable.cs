using System;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for sorting.
    /// </summary>
    /// <typeparam name="TList">Return type.</typeparam>
    /// <typeparam name="TSort">Sort type.</typeparam>
    public interface ISortable<out TList, out TSort>
    {
        /// <summary>
        /// Sorts a list.
        /// </summary>
        /// <param name="sort">Sort expressions.</param>
        /// <returns>List of models.</returns>
        TList Sort(params Func<TSort, SortExpression>[] sort);
    }
}
