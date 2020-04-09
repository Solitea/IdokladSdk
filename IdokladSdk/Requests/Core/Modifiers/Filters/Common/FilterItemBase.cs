namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter item base class.
    /// </summary>
    public class FilterItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterItemBase"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        public FilterItemBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }
    }
}
