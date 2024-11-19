using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
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
        public BankStatementGetModel BankStatement { get; set; }

        /// <summary>
        /// Gets or sets the associated cash voucher.
        /// </summary>
        public CashVoucherGetModel CashVoucher { get; set; }

        /// <summary>
        /// Gets or sets the associated currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

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
        public PaymentOptionGetModel PaymentOption { get; set; }
    }
}
