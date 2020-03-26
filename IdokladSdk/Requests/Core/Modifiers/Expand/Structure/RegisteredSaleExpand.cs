using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for Registered Sale.
    /// </summary>
    public class RegisteredSaleExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets cancelled registered sale.
        /// </summary>
        public RegisteredSaleExpand CancelledRegisteredSale { get; }

        /// <summary>
        /// Gets cash voucher.
        /// </summary>
        public CashVoucherExpand CashVoucher { get; }

        /// <summary>
        /// Gets issued invoice.
        /// </summary>
        public IssuedInvoiceExpand IssuedInvoice { get; }

        /// <summary>
        /// Gets issued invoice payment.
        /// </summary>
        public IssuedDocumentPaymentExpand IssuedInvoicePayment { get; }

        /// <summary>
        /// Gets sales pos equipment.
        /// </summary>
        public SalesPosEquipmentExpand SalesPosEquipment { get; }

        /// <summary>
        /// Gets sales receipt.
        /// </summary>
        public SalesReceiptExpand SalesReceipt { get; }
    }
}
