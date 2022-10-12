using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceipt model for Patch endpoints.
    /// </summary>
    public class SalesReceiptPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [NullableForeignKey]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets Date of issue.
        /// </summary>
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Electronic records of sales information.
        /// Only for Cz legislation.
        /// </summary>
        public ElectronicRecordsOfSalesPostModel ElectronicRecordsOfSales { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets Number assigned by external application.
        /// </summary>
        [StringLength(20)]
        public string ExternalDocumentNumber { get; set; }

        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indication whether document is used for income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets List of items.
        /// </summary>
        [MinCollectionLength(1, true)]
        public List<SalesReceiptItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets partner address.
        /// </summary>
        public DocumentAddressPatchModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> PartnerId { get; set; }

        /// <summary>
        /// Gets or sets List of payments.
        /// </summary>
        [CollectionRange(1, 2, true)]
        public List<SalesReceiptPaymentPatchModel> Payments { get; set; }

        /// <summary>
        /// Gets or sets POS equipment id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }
    }
}
