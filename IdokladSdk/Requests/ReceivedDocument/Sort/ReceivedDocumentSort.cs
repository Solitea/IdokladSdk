using IdokladSdk.Models.ReceivedDocument.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.ReceivedDocument.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="ReceivedDocumentListGetModel"/>.
    /// </summary>
    public class ReceivedDocumentSort : IdSort
    {
        /// <inheritdoc cref="ReceivedDocumentListGetModel.DocumentType"/>
        public SortItem DocumentType { get; set; } = new SortItem(nameof(ReceivedDocumentListGetModel.DocumentType));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(ReceivedDocumentListGetModel.DocumentNumber));

        /// <inheritdoc cref="ReceivedDocumentListGetModel.DateOfReceiving"/>
        public SortItem DateOfReceiving { get; set; } = new SortItem(nameof(ReceivedDocumentListGetModel.DateOfReceiving));
    }
}
