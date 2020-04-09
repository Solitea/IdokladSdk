using IdokladSdk.Models.Tag;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Tag.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="TagListGetModel"/>.
    /// </summary>
    public class TagFilter : IdFilter
    {
        /// <inheritdoc cref="TagListGetModel.Name"/>
        public ContainFilterItem<string> Name { get; set; } = new ContainFilterItem<string>(nameof(TagListGetModel.Name));
    }
}
