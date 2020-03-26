using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for Cash Voucher.
    /// </summary>
    public class CashVoucherExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }

        /// <summary>
        /// Gets partner.
        /// </summary>
        public ContactExpand Partner { get; }

        /// <summary>
        /// Gets cash register.
        /// </summary>
        public CashRegisterExpand CashRegister { get; }
    }
}
