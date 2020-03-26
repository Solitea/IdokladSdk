namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Contain filter item.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class ContainFilterItem<T> : FilterItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainFilterItem{T}"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public ContainFilterItem(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Item contains given value.
        /// </summary>
        /// <param name="value">Value to find.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression Contains(T value)
        {
            return new FilterExpression(Name, FilterOperator.Ct, value);
        }

        /// <summary>
        /// Item does not contain given value.
        /// </summary>
        /// <param name="value">Value to exclude.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression NotContains(T value)
        {
            return new FilterExpression(Name, FilterOperator.Nct, value);
        }
    }
}
