using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Patch model for CashVoucher.
    /// </summary>
    public class CashVoucherPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets cash register id.
        /// </summary>
        [NullableForeignKey]
        public int? CashRegisterId { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfTransaction { get; set; }

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
        /// Gets or sets include subject to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets cash voucher item models.
        /// </summary>
        public List<CashVoucherItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets document name or description.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets id of the partner's contact.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerContactId { get; set; }

        /// <summary>
        /// Gets or sets name of the supplier/customer. Can also be used as a note.
        /// </summary>
        [StringLength(100)]
        public string Person { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [StringLength(10)]
        public string VariableSymbol { get; set; }
    }
}
