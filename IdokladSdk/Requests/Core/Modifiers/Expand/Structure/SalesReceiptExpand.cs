using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for sales receipt.
    /// </summary>
    public class SalesReceiptExpand : ExpandableEntity
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
        /// Gets salesPosEquipment.
        /// </summary>
        public SalesPosEquipmentExpand SalesPosEquipment { get; }

        /// <summary>
        /// Gets Items.
        /// </summary>
        public SalesReceiptItemExpand Items { get; }

        /// <summary>
        /// Gets Payments.
        /// </summary>
        public SalesReceiptPaymentExpand Payments { get; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public TagsExpand Tags { get; set; }
    }
}
