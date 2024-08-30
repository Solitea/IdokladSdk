using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common.PairedDocument;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// POST model for CashVoucher.
    /// </summary>
    public class CashVoucherPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets cash register id.
        /// </summary>
        [RequiredNonDefault]
        public int CashRegisterId { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction.
        /// </summary>
        [Required]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        public DateTime DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        [Required]
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets electronic records of sales information.
        /// </summary>
        [Obsolete]
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
        /// Gets or sets a value indicating whether include subject to income tax.
        /// </summary>
        [Required]
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets model of entity for inserting a new item.
        /// </summary>
        [Required]
        public List<CashVoucherItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the movement type (issue/entry).
        /// </summary>
        [Required]
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets document name or description.
        /// </summary>
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Paired document.
        /// </summary>
        public PairedDocumentPostModel PairedDocument { get; set; }

        /// <summary>
        /// Gets or sets id of the partner's contact.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

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
