using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Account.Agenda.Filter;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.Account.Agenda
{
    /// <summary>
    /// AgendaList.
    /// </summary>
    public class AgendaList : BaseList<AgendaList, AccountClient, AgendaGetModel, AgendaFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgendaList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public AgendaList(AccountClient client)
            : base(client)
        {
        }

        /// <inheritdoc />
        protected override string ListName { get; set; } = "Agendas";
    }
}
