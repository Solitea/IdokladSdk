using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Inbox.Get;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Inbox.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="InboxListGetModel"/>.
    /// </summary>
    public class InboxFilter : IdFilter
    {
        /// <summary>
        /// Gets or sets attachment original file name.
        /// </summary>
        public ContainFilterItem<string> AttachmentOriginalFileName { get; set; } = new ContainFilterItem<string>("AttachmentOriginalFileName");

        /// <summary>
        /// Gets or sets date of receiving.
        /// </summary>
        public CompareFilterItem<DateTime> DateOfReceiving { get; set; } = new CompareFilterItem<DateTime>("DateOfReceiving");

        /// <summary>
        /// Gets or sets processed document id.
        /// </summary>
        public FilterItem<int> DocumentId { get; set; } = new FilterItem<int>("DocumentId");

        /// <summary>
        /// Gets or sets processed document number.
        /// </summary>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>("DocumentNumber");

        /// <summary>
        /// Gets or sets sender email.
        /// </summary>
        public ContainFilterItem<string> SendEmail { get; set; } = new ContainFilterItem<string>("SendEmail");

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public FilterItem<InboxAttachmentStatus> Status { get; set; } = new FilterItem<InboxAttachmentStatus>(nameof(InboxListGetModel.Status));

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public ContainFilterItem<string> Subject { get; set; } = new ContainFilterItem<string>(nameof(Subject));

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public FilterItem<InboxAttachmentType> Type { get; set; } = new FilterItem<InboxAttachmentType>(nameof(InboxListGetModel.Type));
    }
}
