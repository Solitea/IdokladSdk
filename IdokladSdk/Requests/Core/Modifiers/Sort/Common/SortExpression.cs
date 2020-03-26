namespace IdokladSdk.Requests.Core.Modifiers.Sort.Common
{
    /// <summary>
    /// Sort expression.
    /// </summary>
    public class SortExpression
    {
        private readonly SortDirection _direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortExpression"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        /// <param name="direction">Sort direction.</param>
        public SortExpression(string name, SortDirection direction)
        {
            PropertyName = name;
            _direction = direction;
        }

        /// <summary>
        /// Gets property name.
        /// </summary>
        public string PropertyName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return PropertyName + "~" + _direction;
        }
    }
}
