using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.PairedDocument;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.RegisteredSale;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// List model for CashVoucher.
    /// </summary>
    public class CashVoucherListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets cash register id.
        /// </summary>
        public int CashRegisterId { get; set; }

        /// <summary>
        /// Gets or sets the currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction.
        /// </summary>
        public DateTime DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets documentNumber.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets responsibility for handling of electronic records of sales.
        /// </summary>
        [Obsolete]
        public EetResponsibility EetResponsibility { get; set; }

        /// <summary>
        /// Gets or sets eET registration status.
        /// </summary>
        public EetStatus EetStatus { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets export to another accounting software indication.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets id of paired invoice.
        /// </summary>
        [Obsolete("Moved to PairedDocument ")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets type of paired invoice.
        /// </summary>
        [Obsolete("Moved to PairedDocument ")]
        public InvoiceType? InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether indicates whether the cash voucher is registered in EET.
        /// </summary>
        public bool IsEet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include subject to income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets issued tax document id.
        /// </summary>
        public int? IssuedTaxDocumentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether flag for summary cash vouchers from sales receipts.
        /// </summary>
        [Obsolete]
        public bool IsSummarySalesReceipt { get; set; }

        /// <summary>
        /// Gets or sets the cash voucher items.
        /// </summary>
        public List<CashVoucherItemListGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets the movement type.
        /// </summary>
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets your contact information.
        /// </summary>
        public DocumentAddressModel MyAddress { get; set; }

        /// <summary>
        /// Gets or sets Paired document.
        /// </summary>
        public PairedDocumentGetModel PairedDocument { get; set; }

        /// <summary>
        /// Gets or sets document name or description.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public DocumentAddressModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets id of the partner's contact.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets name of the supplier/customer.
        /// Can also be used as a note.
        /// </summary>
        public string Person { get; set; }

        /// <summary>
        /// Gets or sets all recounted prices.
        /// </summary>
        public Prices Prices { get; set; }

        /// <summary>
        /// Gets or sets registered sale.
        /// </summary>
        [Obsolete]
        public RegisteredSaleListGetModel RegisteredSale { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public CashVoucherDependencyStatus Status { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<TagDocumentListGetModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
