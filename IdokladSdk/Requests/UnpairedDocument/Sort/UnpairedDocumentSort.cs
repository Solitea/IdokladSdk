using IdokladSdk.Models.UnpairedDocument.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.UnpairedDocument.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="UnpairedDocumentListGetModel"/>.
    /// </summary>
    public class UnpairedDocumentSort
    {
        /// <inheritdoc cref="UnpairedDocumentListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(UnpairedDocumentListGetModel.DateOfIssue));
    }
}
