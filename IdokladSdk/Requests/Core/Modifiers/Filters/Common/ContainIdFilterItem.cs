using System.Collections.Generic;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Contain filter item.
    /// </summary>
    public class ContainIdFilterItem : FilterItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainIdFilterItem"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public ContainIdFilterItem(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Item contains given id.
        /// </summary>
        /// <param name="id">Id to find.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression Contains(int id)
        {
            return new FilterExpression(Name, FilterOperator.Ct, id);
        }

        /// <summary>
        /// Item contains given ids.
        /// </summary>
        /// <param name="ids">Ids to find.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression Contains(IEnumerable<int> ids)
        {
            return new FilterExpression(Name, FilterOperator.Ct, string.Join(",", ids));
        }
    }
}
