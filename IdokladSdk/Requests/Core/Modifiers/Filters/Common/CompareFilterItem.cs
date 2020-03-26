namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Comparison filters.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class CompareFilterItem<T> : FilterItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompareFilterItem{T}"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public CompareFilterItem(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Item is greater than the value.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsGreaterThan(T value)
        {
            return new FilterExpression(Name, FilterOperator.Gt, value);
        }

        /// <summary>
        /// Item is greater than or equal to the value.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsGreaterThanOrEqual(T value)
        {
            return new FilterExpression(Name, FilterOperator.Gte, value);
        }

        /// <summary>
        /// Item is lower than the value.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsLowerThan(T value)
        {
            return new FilterExpression(Name, FilterOperator.Lt, value);
        }

        /// <summary>
        /// Item is lower than or equal to the value.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsLowerThanOrEqual(T value)
        {
            return new FilterExpression(Name, FilterOperator.Lte, value);
        }
    }
}
