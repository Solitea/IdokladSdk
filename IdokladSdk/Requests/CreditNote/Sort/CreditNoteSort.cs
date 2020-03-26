using IdokladSdk.Models.CreditNote;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.CreditNote.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="CreditNoteListGetModel"/>.
    /// </summary>
    public class CreditNoteSort : IdSort
    {
        /// <inheritdoc cref="CreditNoteListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(CreditNoteListGetModel.DateOfIssue));

        /// <inheritdoc cref="CreditNoteListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(CreditNoteListGetModel.DocumentNumber));
    }
}
