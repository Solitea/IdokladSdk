namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter for an optional ID that also supports matching a list of IDs.
    /// </summary>
    public class NullableContainIdFilterItem : ContainIdFilterItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableContainIdFilterItem"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public NullableContainIdFilterItem(string name)
            : base(name)
        {
        }

        /// <inheritdoc cref="FilterItem{T}.IsEqual"/>
        public FilterExpression IsEqual(int? value)
        {
            return new FilterExpression(Name, FilterOperator.Eq, value);
        }

        /// <inheritdoc cref="FilterItem{T}.IsNotEqual"/>
        public FilterExpression IsNotEqual(int? value)
        {
            return new FilterExpression(Name, FilterOperator.Neq, value);
        }
    }
}
