namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Semantic search filter item.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class SemanticSearchFilterItem<T> : ContainFilterItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticSearchFilterItem{T}"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public SemanticSearchFilterItem(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Item check using semantic search.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression SemanticSearch(T value)
        {
            return new FilterExpression(Name, FilterOperator.Ss, value, GetCoding(value));
        }
    }
}
