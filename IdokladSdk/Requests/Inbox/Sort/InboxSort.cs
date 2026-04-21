using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Inbox.Sort
{
    /// <summary>
    /// Sortable properties of inbox list.
    /// </summary>
    public class InboxSort : IdSort
    {
        /// <summary>
        /// Gets or sets attachment original file name sort item.
        /// </summary>
        public SortItem AttachmentOriginalFileName { get; set; } = new SortItem("AttachmentOriginalFileName");

        /// <summary>
        /// Gets or sets date of receiving sort item.
        /// </summary>
        public SortItem DateOfReceiving { get; set; } = new SortItem("DateOfReceiving");

        /// <summary>
        /// Gets or sets document id sort item.
        /// </summary>
        public SortItem DocumentId { get; set; } = new SortItem("DocumentId");

        /// <summary>
        /// Gets or sets document number sort item.
        /// </summary>
        public SortItem DocumentNumber { get; set; } = new SortItem("DocumentNumber");

        /// <summary>
        /// Gets or sets sender email sort item.
        /// </summary>
        public SortItem SendEmail { get; set; } = new SortItem("SendEmail");

        /// <summary>
        /// Gets or sets status sort item.
        /// </summary>
        public SortItem Status { get; set; } = new SortItem("Status");

        /// <summary>
        /// Gets or sets subject sort item.
        /// </summary>
        public SortItem Subject { get; set; } = new SortItem("Subject");

        /// <summary>
        /// Gets or sets type sort item.
        /// </summary>
        public SortItem Type { get; set; } = new SortItem("Type");
    }
}
