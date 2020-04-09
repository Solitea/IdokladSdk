using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for tags.
    /// </summary>
    public class TagsExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets tag.
        /// </summary>
        public ExpandableEntity Tag { get; }
    }
}
