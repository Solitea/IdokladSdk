namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter item.
    /// </summary>
    /// <typeparam name="T">Type of item.</typeparam>
    public class FilterItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterItem{T}"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public FilterItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Determine equality.
        /// </summary>
        /// <param name="value">Filter value.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsEqual(T value)
        {
            return new FilterExpression(Name, FilterOperator.Eq, value);
        }

        /// <summary>
        /// Determine inequality.
        /// </summary>
        /// <param name="value">Filter value.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsNotEqual(T value)
        {
            return new FilterExpression(Name, FilterOperator.Neq, value);
        }
    }
}
