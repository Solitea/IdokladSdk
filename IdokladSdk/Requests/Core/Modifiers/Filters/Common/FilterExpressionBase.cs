using System;
using System.Runtime.InteropServices.ComTypes;

namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter expression base class.
    /// </summary>
    public abstract class FilterExpressionBase
    {
        /// <summary>
        /// Operator true.
        /// </summary>
        /// <param name="expression">Expression.</param>
        /// <returns>False (to prevent short-circuit evaluation of conditional logical and).</returns>
        public static bool operator true(FilterExpressionBase expression)
        {
            _ = expression;
            return false;
        }

        /// <summary>
        /// Operator False.
        /// </summary>
        /// <param name="expression">Expression.</param>
        /// <returns>False (to prevent short-circuit evaluation of conditional logical or).</returns>
        public static bool operator false(FilterExpressionBase expression)
        {
            _ = expression;
            return false;
        }

        /// <summary>
        /// Custom AND operator.
        /// </summary>
        /// <param name="lhs">Left expression.</param>
        /// <param name="rhs">Right expression.</param>
        /// <returns>Expressions combined with AND operator.</returns>
        public static FilterExpressionBase operator &(FilterExpressionBase lhs, FilterExpressionBase rhs)
        {
            return JoinFilterExpression(lhs, rhs, FilterType.And);
        }

        /// <summary>
        /// Custom OR operator.
        /// </summary>
        /// <param name="lhs">Left expression.</param>
        /// <param name="rhs">Right expression.</param>
        /// <returns>Expressions combined with OR operator.</returns>
        public static FilterExpressionBase operator |(FilterExpressionBase lhs, FilterExpressionBase rhs)
        {
            return JoinFilterExpression(lhs, rhs, FilterType.Or);
        }

        private static FilterExpressionBase JoinFilterExpression(
            FilterExpressionBase firstExpression,
            FilterExpressionBase secondExpression,
            FilterType logicalOperator)
        {
            return new ComplexFilterExpression
            {
                FirstExpression = firstExpression,
                SecondExpression = secondExpression,
                LogicalOperator = logicalOperator
            };
        }
    }
}
