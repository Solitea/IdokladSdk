using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Account.Agenda
{
    /// <summary>
    /// AgendaCurrentDetail.
    /// </summary>
    public class AgendaCurrentDetail : BaseDetail<AgendaCurrentDetail, AccountClient, AgendaGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgendaCurrentDetail"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public AgendaCurrentDetail(AccountClient client)
            : base(client)
        {
        }

        /// <inheritdoc/>
        protected override string DetailName { get; } = "CurrentAgenda";
    }
}
