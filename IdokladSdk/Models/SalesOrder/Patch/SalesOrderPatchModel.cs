using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrder Model for Patch endpoints.
    /// </summary>
    public class SalesOrderPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [NullableForeignKey]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of expiration.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Gets or sets delivery address Id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        public int? DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<SalesOrderItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets my company contact information.
        /// </summary>
        public MyDocumentAddressPatchModel MyAddress { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(25)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public DocumentAddressPatchModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets partner contact id.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [NullableForeignKey]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        public SalesOrderState? State { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }
    }
}
