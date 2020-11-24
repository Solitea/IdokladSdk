using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceipt model for Patch endpoints.
    /// </summary>
    public class SalesReceiptPatchModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Date of issue.
        /// </summary>
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Number assigned by external application.
        /// </summary>
        [StringLength(20)]
        public string ExternalDocumentNumber { get; set; }

        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicationg whether document is used for income tax.
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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> PartnerId { get; set; }

        /// <summary>
        /// Gets or sets partner address.
        /// </summary>
        public DocumentAddressPatchModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets List of payments.
        /// </summary>
        [CollectionRange(1, 2, true)]
        public List<SalesReceiptPaymentPatchModel> Payments { get; set; }

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
