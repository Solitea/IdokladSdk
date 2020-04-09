using IdokladSdk.Models.Tag;

namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// TagDocumentGetModel.
    /// </summary>
    public class TagDocumentGetModel : TagDocumentListGetModel
    {
        /// <summary>
        /// Gets or sets tag.
        /// </summary>
        public TagGetModel Tag { get; set; }
    }
}
