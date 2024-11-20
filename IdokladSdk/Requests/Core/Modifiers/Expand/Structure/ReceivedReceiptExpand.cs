using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ReceivedReceiptExpand.
    /// </summary>
    public class ReceivedReceiptExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets the associated bank statement.
        /// </summary>
        public BankStatementExpand BankStatement { get; set; }

        /// <summary>
        /// Gets or sets the associated cash voucher.
        /// </summary>
        public CashVoucherExpand CashVoucher { get; set; }

        /// <summary>
        /// Gets or sets the associated currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public ReceivedReceiptItemExpand Items { get; set; }

        /// <summary>
        /// Gets or sets the associated partner contact.
        /// </summary>
        public ContactExpand Partner { get; set; }

        /// <summary>
        /// Gets or sets the associated payment option.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }
    }
}
