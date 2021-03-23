using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Account.Subscription.Filter;
using IdokladSdk.Requests.Account.Subscription.Sort;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Account.Subscription
{
    /// <summary>
    /// Subscription List.
    /// </summary>
    public class SubscriptionList : BaseList<SubscriptionList, AccountClient, MySubscriptionGetModel, SubscriptionFilter, SubscriptionSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SubscriptionList(AccountClient client)
            : base(client)
        {
        }

        /// <inheritdoc />
        protected override string ListName { get; set; } = "CurrentAgenda/Subscriptions";
    }
}
