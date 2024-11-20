using IdokladSdk.Enums;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail
{
    /// <summary>
    /// SalesDocumentPaymentForCreditNoteGetModel.
    /// </summary>
    public class SalesDocumentPaymentForCreditNoteGetModel : PaymentBaseGetModel
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
        /// Gets or sets credit note.
        /// </summary>
        public CreditNoteGetModel CreditNote { get; set; }

        /// <summary>
        /// Gets or sets credit note id.
        /// </summary>
        public int CreditNoteId { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets vat on pay status.
        /// </summary>
        public VatOnPayStatus VatOnPayStatus { get; set; }
    }
}
