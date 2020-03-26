namespace IdokladSdk.Requests.Core.Modifiers.Sort.Common
{
    /// <summary>
    /// Sort item.
    /// </summary>
    public class SortItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SortItem"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public SortItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sort ascending.
        /// </summary>
        /// <returns><see cref="SortExpression"/>.</returns>
        public SortExpression Asc()
        {
            return new SortExpression(Name, SortDirection.Asc);
        }

        /// <summary>
        /// Sort descending.
        /// </summary>
        /// <returns><see cref="SortExpression"/>.</returns>
        public SortExpression Desc()
        {
            return new SortExpression(Name, SortDirection.Desc);
        }
    }
}
