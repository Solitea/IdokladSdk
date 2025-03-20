using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedReceipt.Patch
{
    /// <summary>
    /// ReceivedReceiptPatchModel.
    /// </summary>
    public class ReceivedReceiptPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date of issue for the receipt.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets the description of the receipt.
        /// </summary>
        [NotEmptyString]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate for the currency.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the amount of currency for the exchange rate.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets the external document number.
        /// </summary>
        [StringLength(20)]
        public string ExternalDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the entity's ID.
        /// </summary>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the receipt is included in the income tax return.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets the list of invoice items.
        /// </summary>
        public List<ReceivedReceiptItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the partner contact ID.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the payment option ID.
        /// </summary>
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the list of tag IDs.
        /// </summary>
        public List<int> Tags { get; set; }
    }
}
