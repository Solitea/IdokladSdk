using System;
using System.Linq.Expressions;
using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for Expands.
    /// </summary>
    /// <typeparam name="TDetail">Return type.</typeparam>
    /// <typeparam name="TExpandModel">Expand type.</typeparam>
    public interface IExpandable<out TDetail, TExpandModel>
    {
        /// <summary>
        /// Includes other related models.
        /// </summary>
        /// <param name="include">Related models.</param>
        /// <returns>Detail.</returns>
        TDetail Include(params Expression<Func<TExpandModel, ExpandableEntity>>[] include);
    }
}
