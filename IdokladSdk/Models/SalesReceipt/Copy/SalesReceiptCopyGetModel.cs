using System;
using System.Collections.Generic;
using IdokladSdk.Models.RegisteredSale;

namespace IdokladSdk.Models.SalesReceipt.Copy
{
    /// <summary>
    /// SalesReceiptPaymentModel for Copy endpoints.
    /// </summary>
    public class SalesReceiptCopyGetModel
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Document Serial Number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets Electronic records of sales information.
        /// Only for Sk legislation.
        /// </summary>
        public EKasaApiModel EKasa { get; set; }

        /// <summary>
        /// Gets or sets Electronic records of sales information.
        /// Only for Cz legislation.
        /// </summary>
        public ElectronicRecordsOfSalesPostModel ElectronicRecordsOfSales { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets Number assigned by external application.
        /// </summary>
        public string ExternalDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is cumulative.
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is used for income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets List of items. Must be non-empty.
        /// </summary>
        public List<SalesReceiptItemCopyGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets List of payments.
        /// </summary>
        public List<SalesReceiptPaymentPostModel> Payments { get; set; }

        /// <summary>
        /// Gets or sets POS equipment id.
        /// </summary>
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }
    }
}
