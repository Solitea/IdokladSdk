using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// SubscriptionGetModel.
    /// </summary>
    public class SubscriptionGetModel
    {
        /// <summary>
        /// Gets or sets subscription type.
        /// </summary>
        public SubscriptionType? Type { get; set; }

        /// <summary xml:lang="en">
        /// Gets or sets date from.
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Gets or sets date to.
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
