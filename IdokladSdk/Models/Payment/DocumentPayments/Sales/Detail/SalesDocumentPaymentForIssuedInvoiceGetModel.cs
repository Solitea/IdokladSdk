using IdokladSdk.Enums;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail
{
    /// <summary>
    /// SalesDocumentPaymentForIssuedInvoiceGetModel.
    /// </summary>
    public class SalesDocumentPaymentForIssuedInvoiceGetModel : SalesPaymentBaseGetModel
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
        /// Gets or sets a value indicating whether confirmation is sent.
        /// </summary>
        public bool IsConfirmationSent { get; set; }

        /// <summary>
        /// Gets or sets issued invoice.
        /// </summary>
        public IssuedInvoiceGetModel IssuedInvoice { get; set; }

        /// <summary>
        /// Gets or sets issued invoice id.
        /// </summary>
        public int IssuedInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets vat on pay status.
        /// </summary>
        public VatOnPayStatus VatOnPayStatus { get; set; }
    }
}
