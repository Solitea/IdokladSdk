using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.RegisteredSale;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceipt Model for Get list endpoints.
    /// </summary>
    public partial class SalesReceiptListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets currencyId.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets dateOfIssue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets documentNumber.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets documentSerialNumber.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets eetResponsibility.
        /// Only for Cz legislation.
        /// </summary>
        public EetResponsibility EetResponsibility { get; set; }

        /// <summary>
        /// Gets or sets eetStatus.
        /// Only for Cz legislation.
        /// </summary>
        public EetStatus EetStatus { get; set; }

        /// <summary>
        /// Gets or sets exchangeRate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchangeRateAmount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets exported.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <summary>
        /// Gets or sets externalDocumentNumber.
        /// </summary>
        public string ExternalDocumentNumber { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets imported.
        /// </summary>
        public ImportedState Imported { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is accounted.
        /// </summary>
        public bool IsAccounted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is cumulative.
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is registered for EET.
        /// Only for Cz legislation.
        /// </summary>
        public bool IsEet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is used for income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public List<SalesReceiptItemListGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets metadata.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets myAddress.
        /// </summary>
        public DocumentAddressModel MyAddress { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets partnerAddress.
        /// </summary>
        public DocumentAddressModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets partnerId.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payments.
        /// </summary>
        public List<SalesReceiptPaymentListGetModel> Payments { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public Prices Prices { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// Only for Cz legislation.
        /// </summary>
        public RegisteredSaleGetModel RegisteredSale { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// Only for Cz legislation.
        /// </summary>
        public int? SalesPosEquipmentId { get; set; }
    }
}
