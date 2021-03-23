using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Account.Subscription.Sort
{
    /// <summary>
    /// Subscription Sort.
    /// </summary>
    public class SubscriptionSort : IdSort
    {
        /// <inheritdoc cref="MySubscriptionGetModel.DateFrom"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(MySubscriptionGetModel.DateFrom));
    }
}
