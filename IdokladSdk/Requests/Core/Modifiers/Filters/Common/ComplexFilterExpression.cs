namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Complex filter expression.
    /// </summary>
    public class ComplexFilterExpression : FilterExpressionBase
    {
        /// <summary>
        /// Gets or sets first expression.
        /// </summary>
        internal FilterExpressionBase FirstExpression { get; set; }

        /// <summary>
        /// Gets or sets second expression.
        /// </summary>
        internal FilterExpressionBase SecondExpression { get; set; }

        /// <summary>
        /// Gets or sets operator (AND, OR).
        /// </summary>
        internal FilterType LogicalOperator { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({FirstExpression}~{LogicalOperator.ToString().ToLowerInvariant()}~{SecondExpression})";
        }
    }
}
