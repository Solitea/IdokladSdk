using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.Account.Agenda;
using IdokladSdk.Requests.Account.Subscription;
using IdokladSdk.Requests.Account.User;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with account endpoints.
    /// </summary>
    public partial class AccountClient :
        BaseClient,
        IDeleteRequest
    {
        private Agendas _agendas;
        private Users _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public AccountClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Account";

        /// <summary>
        /// Gets agendas.
        /// </summary>
        public Agendas Agendas => _agendas ?? (_agendas = new Agendas(this));

        /// <summary>
        /// Gets users.
        /// </summary>
        public Users Users => _users ?? (_users = new Users(this));

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>($"{ResourceUrl}/Users/" + id);
        }

        /// <summary>
        /// Gives list of subscriptions.
        /// </summary>
        /// <returns>List of subscriptions.</returns>
        public SubscriptionList SubscriptionList()
        {
            return new SubscriptionList(this);
        }
    }
}
