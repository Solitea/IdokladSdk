using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common.PairedDocument;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankStatement.Patch
{
    /// <summary>
    /// BankStatementPatchModel.
    /// </summary>
    public class BankStatementPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets Bank account id.
        /// </summary>
        public int? BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets Constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets The date of transaction.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets Exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets Exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets The entity's Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Include subject to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets Bank statement item models.
        /// </summary>
        public List<BankStatementItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets Paired document.
        /// </summary>
        public PairedDocumentPatchModel PairedDocument { get; set; }

        /// <summary>
        /// Gets or sets The partner's account number.
        /// </summary>
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
        /// Gets or sets Supplier contact id.
        /// </summary>
        public int? PartnerId { get; set; }

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
