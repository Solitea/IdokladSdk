using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.ReceivedDocument.List;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReceivedDocument.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="ReceivedDocumentListGetModel"/>.
    /// </summary>
    public class ReceivedDocumentFilter : IdFilter
    {
        /// <inheritdoc cref="ReceivedDocumentListGetModel.DocumentType"/>
        public FilterItem<InboxAttachmentDocumentType> DocumentType { get; set; } = new FilterItem<InboxAttachmentDocumentType>(nameof(ReceivedDocumentListGetModel.DocumentType));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(ReceivedDocumentListGetModel.DocumentNumber));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.VariableSymbol"/>
        public ContainFilterItem<string> VariableSymbol { get; set; } = new ContainFilterItem<string>(nameof(ReceivedDocumentListGetModel.VariableSymbol));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } = new ContainFilterItem<string>(nameof(ReceivedDocumentListGetModel.Description));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.DateOfReceiving"/>
        public CompareFilterItem<DateTime> DateOfReceiving { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedDocumentListGetModel.DateOfReceiving));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.PartnerName"/>
        public ContainFilterItem<string> PartnerName { get; set; } = new ContainFilterItem<string>(nameof(ReceivedDocumentListGetModel.PartnerName));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(ReceivedDocumentListGetModel.PartnerId));
    }
}
