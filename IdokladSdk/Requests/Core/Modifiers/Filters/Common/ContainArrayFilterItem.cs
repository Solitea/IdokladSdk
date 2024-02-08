using System.Collections.Generic;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Contain array filter item.
    /// </summary>
    public class ContainArrayFilterItem : FilterItem<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainArrayFilterItem"/> class.
        /// </summary>
        /// <param name="name">Property name.</param>
        public ContainArrayFilterItem(string name)
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
