using IdokladSdk.Models;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Filters
{
    /// <summary>
    /// Filter by Id.
    /// </summary>
    public class IdFilter
    {
        /// <inheritdoc cref="IEntityId.Id"/>
        public ContainIdFilterItem Id { get; set; } = new ContainIdFilterItem(nameof(IEntityId.Id));
    }
}
