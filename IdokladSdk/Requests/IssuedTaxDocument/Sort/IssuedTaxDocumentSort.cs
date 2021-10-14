using IdokladSdk.Models.IssuedTaxDocument.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.IssuedTaxDocument.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="IssuedTaxDocumentListGetModel"/>.
    /// </summary>
    public class IssuedTaxDocumentSort : IdSort
    {
        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(IssuedTaxDocumentListGetModel.DateOfIssue));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.DateOfTaxing"/>
        public SortItem DateOfTaxing { get; set; } = new SortItem(nameof(IssuedTaxDocumentListGetModel.DateOfTaxing));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(IssuedTaxDocumentListGetModel.DocumentNumber));
    }
}
