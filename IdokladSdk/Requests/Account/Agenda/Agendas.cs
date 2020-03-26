using IdokladSdk.Clients;

namespace IdokladSdk.Requests.Account.Agenda
{
    /// <summary>
    /// Agenda.
    /// </summary>
    public class Agendas
    {
        private readonly AccountClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Agendas" /> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public Agendas(AccountClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Current agenda endpoint.
        /// </summary>
        /// <returns>Method return current detail of agenda.</returns>
        public AgendaCurrentDetail Current()
        {
            return new AgendaCurrentDetail(_client);
        }

        /// <summary>
        /// Detail endpoint.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Method return detail of agenda.</returns>
        public AgendaDetail Detail(int id)
        {
            return new AgendaDetail(id, _client);
        }

        /// <summary>
        /// List enpoint.
        /// </summary>
        /// <returns>Method return list of agendas.</returns>
        public AgendaList List()
        {
            return new AgendaList(_client);
        }
    }
}
