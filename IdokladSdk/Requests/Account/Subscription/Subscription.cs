using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;

namespace IdokladSdk.Requests.Account.Subscription
{
    /// <summary>
    /// Subscription list.
    /// </summary>
    public class Subscription : IEntityList<SubscriptionList>
    {
        private readonly AccountClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public Subscription(AccountClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gives list of subscriptions.
        /// </summary>
        /// <returns>List of subscriptions.</returns>
        public SubscriptionList List()
        {
            return new SubscriptionList(_client);
        }
    }
}
