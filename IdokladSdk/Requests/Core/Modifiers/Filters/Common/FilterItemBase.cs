namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Filter item base class.
    /// </summary>
    public abstract class FilterItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterItemBase"/> class.
        /// </summary>
        /// <param name="name">Item name.</param>
        protected FilterItemBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }
    }
}
