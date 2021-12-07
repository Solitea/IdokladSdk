using System;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Account.Subscription.Filter
{
    /// <summary>
    /// Subscription filter.
    /// </summary>
    public class SubscriptionFilter
    {
        /// <inheritdoc cref="MySubscriptionGetModel.DateFrom"/>
        public CompareFilterItem<DateTime> DateFrom { get; set; } =
            new CompareFilterItem<DateTime>(nameof(MySubscriptionGetModel.DateFrom));

        /// <inheritdoc cref="MySubscriptionGetModel.IsCanceled"/>
        public FilterItem<bool> IsCanceled { get; set; } =
            new FilterItem<bool>(nameof(MySubscriptionGetModel.IsCanceled));
    }
}
