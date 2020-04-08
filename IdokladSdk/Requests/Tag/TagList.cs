using IdokladSdk.Clients;
using IdokladSdk.Models.Tag;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Tag.Filter;

namespace IdokladSdk.Requests.Tag
{
    /// <summary>
    /// TagList.
    /// </summary>
    public class TagList : BaseList<TagList, TagClient, TagListGetModel, TagFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public TagList(TagClient client)
            : base(client)
        {
        }
    }
}
