using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptPaymentModel for Post enpoints.
    /// </summary>
    public class SalesReceiptPostModel
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        [Required]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Document Serial Number.
        /// </summary>
        [Required]
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets Electronic records of sales information.
        /// Only for Cz legislation.
        /// </summary>
        public ElectronicRecordsOfSalesPostModel ElectronicRecordsOfSales { get; set; }

        /// <summary>
        /// Gets or sets Electronic records of sales information.
        /// Only for Sk legislation.
        /// </summary>
        public EKasaApiModel EKasa { get; set; }

        /// <summary>
        /// Gets or sets Number assigned by external application.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string ExternalDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is cumulative.
        /// </summary>
        [Required]
        public bool IsCumulative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document is used for income tax.
        /// </summary>
        [Required]
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets List of items. Must be non-empty.
        /// </summary>
        [MinCollectionLength(1)]
        public List<SalesReceiptItemPostModel> Items { get; set; }

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
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets List of payments.
        /// </summary>
        [CollectionRange(1, 2)]
        public List<SalesReceiptPaymentPostModel> Payments { get; set; }

        /// <summary>
        /// Gets or sets POS equipment id.
        /// </summary>
        [NullableForeignKey]
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }
    }
}
