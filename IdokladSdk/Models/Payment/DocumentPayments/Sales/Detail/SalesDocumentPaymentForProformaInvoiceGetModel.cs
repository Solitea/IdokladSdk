using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail
{
    /// <summary>
    /// SalesDocumentPaymentForProformaInvoiceGetModel.
    /// </summary>
    public class SalesDocumentPaymentForProformaInvoiceGetModel : SalesPaymentBaseGetModel
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
        /// Gets or sets is accounted.
        /// </summary>
        public bool IsAccounted { get; set; }

        /// <summary>
        /// Gets or sets is confirmation sent.
        /// </summary>
        public bool IsConfirmationSent { get; set; }

        /// <summary>
        /// Gets or sets issued tax document.
        /// </summary>
        public IssuedTaxDocumentGetModel IssuedTaxDocument { get; set; }

        /// <summary>
        /// Gets or sets issued tax document id.
        /// </summary>
        public int? IssuedTaxDocumentId { get; set; }

        /// <summary>
        /// Gets or sets proforma invoice.
        /// </summary>
        public ProformaInvoiceGetModel ProformaInvoice { get; set; }

        /// <summary>
        /// Gets or sets proforma invoice id.
        /// </summary>
        public int ProformaInvoiceId { get; set; }
    }
}
