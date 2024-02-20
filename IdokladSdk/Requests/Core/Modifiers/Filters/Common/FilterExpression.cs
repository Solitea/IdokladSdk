using System;
using System.Globalization;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter expression.
    /// </summary>
    public class FilterExpression : FilterExpressionBase
    {
        private readonly string _name;
        private readonly FilterOperator _operator;
        private readonly object _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterExpression"/> class.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="operator">Operator.</param>
        /// <param name="value">Value.</param>
        public FilterExpression(string name, FilterOperator @operator, object value)
        {
            _name = name;
            _operator = @operator;
            _value = value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "(" + _name + "~" + _operator.ToString().ToLowerInvariant().Replace("n", "!") + "~" + GetValue() + ")";
        }

        private string GetValue()
        {
            if (_value is DateTime dateValue)
            {
                return dateValue.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            }
            else if (_value is bool)
            {
                return _value.ToString().ToLowerInvariant();
            }
            else if (_value is null)
            {
                return "null";
            }

            return _value.ToString();
        }
    }
}
