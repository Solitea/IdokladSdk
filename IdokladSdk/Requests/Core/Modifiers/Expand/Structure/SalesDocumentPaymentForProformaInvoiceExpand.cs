using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for proforma invoice.
    /// </summary>
    public class SalesDocumentPaymentForProformaInvoiceExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets accounting invoice.
        /// </summary>
        public IssuedInvoiceGetModel AccountedByInvoice { get; set; }

        /// <summary>
        /// Gets or sets bank statement.
        /// </summary>
        public BankStatementExpand BankStatement { get; set; }

        /// <summary>
        /// Gets or sets cash voucher.
        /// </summary>
        public CashVoucherExpand CashVoucher { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets issued tax document.
        /// </summary>
        public IssuedTaxDocumentExpand IssuedTaxDocument { get; set; }

        /// <summary>
        /// Gets or sets proforma invoice.
        /// </summary>
        public ProformaInvoiceExpand ProformaInvoice { get; set; }
    }
}
