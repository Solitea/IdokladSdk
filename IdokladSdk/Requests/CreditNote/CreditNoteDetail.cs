using IdokladSdk.Clients;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.CreditNote
{
    /// <summary>
    /// Detail of credit note.
    /// </summary>
    public class CreditNoteDetail : ExpandableDetail<CreditNoteDetail, CreditNoteClient, CreditNoteGetModel, CreditNoteExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditNoteDetail"/> class.
        /// </summary>
        /// <param name="id">Credit note id.</param>
        /// <param name="client">Credit note client.</param>
        public CreditNoteDetail(int id, CreditNoteClient client)
            : base(id, client)
        {
        }
    }
}
