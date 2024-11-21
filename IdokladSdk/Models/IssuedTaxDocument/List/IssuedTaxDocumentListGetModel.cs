using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.IssuedTaxDocument.Get;

namespace IdokladSdk.Models.IssuedTaxDocument.List
{
    /// <summary>
    /// IssuedTaxDocumentListGetModel.
    /// </summary>
    public class IssuedTaxDocumentListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets AccountedByInvoiceId.
        /// </summary>
        public int? AccountedByInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets CurrencyId.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets DateOfAccountingEvent.
        /// </summary>
        public DateTime DateOfAccountingEvent { get; set; }

        /// <summary>
        /// Gets or sets DateOfIssue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets DateOfTaxing. Date of taxable supply for SK legislation.
        /// </summary>
        public DateTime DateOfTaxing { get; set; }

        /// <summary>
        /// Gets or sets DocumentNumber.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets DocumentSerialNumber.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRateAmount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets Exported.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Issued tax document is sent to accountant.
        /// </summary>
        public bool IsSentToAccountant { get; set; }

        /// <summary>
        /// Gets or sets IsSentToPartner.
        /// </summary>
        public MailSentType IsSentToPartner { get; set; }

        /// <summary>
        /// Gets or sets Issued tax document Items.
        /// </summary>
        public List<IssuedTaxDocumentItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets Metadata.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets MyAddress.
        /// </summary>
        public DocumentAddressModel MyAddress { get; set; }

        /// <summary>
        /// Gets or sets PartnerAddress.
        /// </summary>
        public DocumentAddressModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets PartnerId.
        /// </summary>
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets PaymentId.
        /// </summary>
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets Prices.
        /// </summary>
        public TaxDocumentItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets ProformaInvoiceId.
        /// </summary>
        public int ProformaInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets ReportLanguage.
        /// </summary>
        public Language ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets VariableSymbol.
        /// </summary>
        public string VariableSymbol { get; set; }
    }
}
