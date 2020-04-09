using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for sales order.
    /// </summary>
    public class SalesOrderExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets partner.
        /// </summary>
        public ContactExpand Partner { get; }

        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }

        /// <summary>
        /// Gets Items.
        /// </summary>
        public SalesOrderItemExpand Items { get; }

        /// <summary>
        /// Gets or sets paymentOption.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public TagsExpand Tags { get; set; }
    }
}
