using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common.PairedDocument;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankStatement.Post
{
    /// <summary>
    /// POST model for BankStatement.
    /// </summary>
    public class BankStatementPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets Bank account id.
        /// </summary>
        [RequiredNonDefault]
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets Constant symbol Id.
        /// </summary>
        [NullableForeignKey]
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets The date of transaction.
        /// </summary>
        [Required]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        public DateTime DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Document Serial Number.
        /// </summary>
        [Required]
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets Exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets Exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets export to another accounting software indication. (It is recommended to use only one external accounting software beside iDoklad.).
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include subject to income tax.
        /// </summary>
        [Required]
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets Model of entity for inserting a new item.
        /// </summary>
        [Required]
        [MinCollectionLength(1)]
        public List<BankStatementItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets The movement type (issue/entry).
        /// </summary>
        [Required]
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets Paired document.
        /// </summary>
        public PairedDocumentPostModel PairedDocument { get; set; }

        /// <summary>
        /// Gets or sets The partner's account number.
        /// </summary>
        [BankAccountNumber]
        [StringLength(50)]
        public string PartnerAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets The partner's bank code.
        /// </summary>
        [StringLength(10)]
        public string PartnerBankCode { get; set; }

        /// <summary>
        /// Gets or sets The partner's IBAN.
        /// </summary>
        [StringLength(50)]
        public string PartnerIban { get; set; }

        /// <summary>
        /// Gets or sets Id of the partner's contact.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets Swift code.
        /// </summary>
        [StringLength(11)]
        public string PartnerSwift { get; set; }

        /// <summary>
        /// Gets or sets Specific symbol.
        /// </summary>
        [StringLength(10)]
        public string SpecificSymbol { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        public List<int> Tags { get; set; }

        /// <summary>
        /// Gets or sets Variable symbol.
        /// </summary>
        [StringLength(10)]
        public string VariableSymbol { get; set; }
    }
}
