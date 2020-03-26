using IdokladSdk.Clients;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.CreditNote.Filter;
using IdokladSdk.Requests.CreditNote.Sort;

namespace IdokladSdk.Requests.CreditNote
{
    /// <summary>
    /// List of credit notes.
    /// </summary>
    public class CreditNoteList : BaseList<CreditNoteList, CreditNoteClient, CreditNoteListGetModel, CreditNoteFilter, CreditNoteSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditNoteList"/> class.
        /// </summary>
        /// <param name="client">Credit note client.</param>
        public CreditNoteList(CreditNoteClient client)
            : base(client)
        {
        }
    }
}
