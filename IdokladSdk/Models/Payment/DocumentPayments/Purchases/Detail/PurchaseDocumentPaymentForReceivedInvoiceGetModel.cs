using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReceivedInvoice;

namespace IdokladSdk.Models.Payment.DocumentPayments.Purchases.Detail
{
    /// <summary>
    /// PurchaseDocumentPaymentForReceivedInvoiceGetModel.
    /// </summary>
    public class PurchaseDocumentPaymentForReceivedInvoiceGetModel : PaymentBaseGetModel
    {
        /// <summary>
        /// Gets or sets bank statement.
        /// </summary>
        public BankStatementGetModel BankStatement { get; set; }

        /// <summary>
        /// Gets or sets bank statement id.
        /// </summary>
        public int? BankStatementId { get; set; }

        /// <summary>
        /// Gets or sets cash voucher.
        /// </summary>
        public CashVoucherGetModel CashVoucher { get; set; }

        /// <summary>
        /// Gets or sets cash voucher id.
        /// </summary>
        public int? CashVoucherId { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets received invoice.
        /// </summary>
        public ReceivedInvoiceGetModel ReceivedInvoice { get; set; }

        /// <summary>
        /// Gets or sets received invoice id.
        /// </summary>
        public int ReceivedInvoiceId { get; set; }
    }
}
