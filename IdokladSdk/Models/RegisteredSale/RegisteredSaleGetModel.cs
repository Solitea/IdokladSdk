using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.Payment;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Models.SalesReceipt;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// RegisteredSale Model for Get endpoints.
    /// </summary>
    public class RegisteredSaleGetModel : RegisteredSaleListGetModel
    {
        /// <summary>
        /// Gets or sets CancelledRegisteredSale.
        /// </summary>
        public RegisteredSaleGetModel CancelledRegisteredSale { get; set; }

        /// <summary>
        /// Gets or sets CashVoucher.
        /// </summary>
        public CashVoucherGetModel CashVoucher { get; set; }

        /// <summary>
        /// Gets or sets IssuedInvoice.
        /// </summary>
        public IssuedInvoiceGetModel IssuedInvoice { get; set; }

        /// <summary>
        /// Gets or sets IssuedInvoicePayment.
        /// </summary>
        public IssuedDocumentPaymentGetModel IssuedInvoicePayment { get; set; }

        /// <summary>
        /// Gets or sets SalesPosEquipment.
        /// </summary>
        public SalesPosEquipmentGetModel SalesPosEquipment { get; set; }

        /// <summary>
        /// Gets or sets SalesReceipt.
        /// </summary>
        public SalesReceiptGetModel SalesReceipt { get; set; }
    }
}
