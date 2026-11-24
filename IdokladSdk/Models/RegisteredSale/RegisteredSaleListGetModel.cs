using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Models.SalesReceipt;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// RegisteredSaleListGetModel.
    /// </summary>
    public class RegisteredSaleListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Canceled registered sale id.
        /// </summary>
        public int? CancelledRegisteredSaleId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="CashVoucherGetModel">cash voucher</see> id.
        /// </summary>
        public int? CashVoucherId { get; set; }

        /// <summary>
        /// Gets or sets Date of answer.
        /// </summary>
        public DateTime DateOfAnswer { get; set; }

        /// <summary>
        /// Gets or sets Date of sale.
        /// </summary>
        public DateTime DateOfSale { get; set; }

        /// <summary>
        /// Gets or sets Date of send.
        /// </summary>
        public DateTime DateOfSend { get; set; }

        /// <summary>
        /// Gets or sets Document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets Document type.
        /// </summary>
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the confirmation code.
        /// </summary>
        public string Pok { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether sale is canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether sale is first report.
        /// </summary>
        public bool IsFirstReport { get; set; }

        /// <summary>
        /// Gets or sets <see cref="IssuedInvoiceItemGetModel"> Issued invoice</see> id.
        /// </summary>
        public int? IssuedInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets Payment id.
        /// </summary>
        public int? IssuedInvoicePaymentId { get; set; }

        /// <summary>
        /// Gets or sets Additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets the total price including VAT in home currency.
        /// </summary>
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets the amount in CZK received for later use or settlement.
        /// </summary>
        public decimal TotalAdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets the amount in CZK used or settled from a previously received payment.
        /// </summary>
        public decimal TotalFromAdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets Receipt number.
        /// </summary>
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets Sales office designation.
        /// </summary>
        public int SalesOfficeDesignation { get; set; }

        /// <summary>
        /// Gets or sets Point of sale equipment designation.
        /// </summary>
        public string SalesPosEquipmentDesignation { get; set; }

        /// <summary>
        /// Gets or sets <see cref="SalesPosEquipmentGetModel">Pos sale equipment</see> id.
        /// </summary>
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="SalesReceiptGetModel">Sales receipt</see> id.
        /// </summary>
        public int? SalesReceiptId { get; set; }

        /// <summary>
        /// Gets or sets Eet registration status.
        /// </summary>
        public RegisteredSaleState Status { get; set; }

        /// <summary>
        /// Gets or sets Universally unique identifier.
        /// </summary>
        public Guid Uuid { get; set; }
    }
}
