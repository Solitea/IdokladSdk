using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Account.Agenda
{
    /// <summary>
    /// AgendaDetail.
    /// </summary>
    public class AgendaDetail : EntityDetail<AgendaDetail, AccountClient, AgendaGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgendaDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public AgendaDetail(int id, AccountClient client)
            : base(id, client)
        {
        }

        /// <inheritdoc />
        protected override string DetailName { get; } = "Agendas";
    }
}
