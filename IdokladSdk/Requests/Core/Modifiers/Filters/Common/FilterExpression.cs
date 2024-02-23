using System;
using System.Globalization;
using IdokladSdk.Requests.Core.Extensions;

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
        private readonly FilterValueCoding _valueCoding;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterExpression"/> class.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="operator">Operator.</param>
        /// <param name="value">Value.</param>
        /// <param name="valeCoding">Value coding.</param>
        public FilterExpression(
            string name,
            FilterOperator @operator,
            object value,
            FilterValueCoding valeCoding = FilterValueCoding.None)
        {
            _name = name;
            _operator = @operator;
            _value = value;
            _valueCoding = valeCoding;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "(" + _name + "~" + GetOperator() + "~" + GetValue() + ")";
        }

        private string GetOperator()
        {
            var operatorValue = _operator.ToString().ToLowerInvariant().Replace("n", "!");
            return _valueCoding == FilterValueCoding.None ? operatorValue : $"{operatorValue}:base64";
        }

        private string GetValue()
        {
            if (_value is DateTime dateValue)
            {
                return dateValue.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            }

            if (_value is bool)
            {
                return _value.ToString().ToLowerInvariant();
            }

            if (_value is null)
            {
                return "null";
            }

            if (_value is string stringValue && _valueCoding == FilterValueCoding.Base64)
            {
                return stringValue.ToBase64();
            }

            return _value.ToString();
        }
    }
}
