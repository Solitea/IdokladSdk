using IdokladSdk.Requests.Core.Extensions;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter item.
    /// </summary>
    /// <typeparam name="T">Type of item.</typeparam>
    public class FilterItem<T> : FilterItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterItem{T}"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public FilterItem(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Determine equality.
        /// </summary>
        /// <param name="value">Filter value.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsEqual(T value)
        {
            return new FilterExpression(Name, FilterOperator.Eq, value, GetCoding(value));
        }

        /// <summary>
        /// Determine inequality.
        /// </summary>
        /// <param name="value">Filter value.</param>
        /// <returns>Filter expression.</returns>
        public FilterExpression IsNotEqual(T value)
        {
            return new FilterExpression(Name, FilterOperator.Neq, value, GetCoding(value));
        }

        /// <summary>
        /// Determine value coding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Value coding.</returns>
        protected FilterValueCoding GetCoding(T value)
        {
            if (value is string stringValue && stringValue.IsNotNullOrEmpty())
            {
                return FilterValueCoding.Base64;
            }

            return FilterValueCoding.None;
        }
    }
}
