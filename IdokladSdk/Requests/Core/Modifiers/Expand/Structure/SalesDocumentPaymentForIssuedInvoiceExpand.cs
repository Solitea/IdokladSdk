using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for issued invoice.
    /// </summary>
    public class SalesDocumentPaymentForIssuedInvoiceExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets bank statement.
        /// </summary>
        public BankStatementExpand BankStatement { get; }

        /// <summary>
        /// Gets cash voucher.
        /// </summary>
        public CashVoucherExpand CashVoucher { get; }

        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }

        /// <summary>
        /// Gets issued invoice.
        /// </summary>
        public IssuedInvoiceExpand IssuedInvoice { get; }
    }
}
