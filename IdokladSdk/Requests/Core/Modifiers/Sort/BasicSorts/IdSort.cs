using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts
{
    /// <summary>
    /// Sort by Id.
    /// </summary>
    public class IdSort
    {
        /// <summary>
        /// Gets or sets id for sort.
        /// </summary>
        public SortItem Id { get; set; } = new SortItem("Id");
    }
}
