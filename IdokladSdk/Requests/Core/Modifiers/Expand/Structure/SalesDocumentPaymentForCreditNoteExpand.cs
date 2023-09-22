using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for credit note.
    /// </summary>
    public class SalesDocumentPaymentForCreditNoteExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets bank statement.
        /// </summary>
        public BankStatementExpand BankStatement { get;  }

        /// <summary>
        /// Gets cash voucher.
        /// </summary>
        public CashVoucherExpand CashVoucher { get; }

        /// <summary>
        /// Gets credit note.
        /// </summary>
        public CreditNoteExpand CreditNote { get; }

        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }
    }
}
