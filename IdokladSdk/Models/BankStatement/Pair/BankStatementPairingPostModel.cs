using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementPairingPostModel.
    /// </summary>
    public class BankStatementPairingPostModel
    {
        /// <summary>
        /// Gets or sets your account number.
        /// </summary>
        [StringLength(50)]
        [RequiredIf(nameof(Iban), null)]
        [RequiredIf(nameof(Iban), "")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets amount sent.
        /// </summary>
        [Required]
        [CannotEqual(0, "The amount must be either positive or negative.")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets account balance.
        /// </summary>
        [Required]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets bank code.
        /// </summary>
        [StringLength(10)]
        [RequiredIf(nameof(Iban), null)]
        [RequiredIf(nameof(Iban), "")]
        public string BankCode { get; set; }

        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        [StringLength(4)]
        public string ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets currency code.
        /// </summary>
        [StringLength(3)]
        [Required]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets date of transaction. If not set, the current date will be used.
        /// </summary>
        public DateTime? DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets your IBAN.
        /// </summary>
        [StringLength(50)]
        [RequiredIf(nameof(AccountNumber), null)]
        [RequiredIf(nameof(AccountNumber), "")]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets message for the partner.
        /// </summary>
        [StringLength(200)]
        public string MessageForPartner { get; set; }

        /// <summary>
        /// Gets or sets movement type.
        /// </summary>
        [Required]
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets the partner's account number.
        /// </summary>
        [StringLength(50)]
        public string PartnerAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the partner's bank code.
        /// </summary>
        [StringLength(10)]
        public string PartnerBankCode { get; set; }

        /// <summary>
        /// Gets or sets the partner's IBAN.
        /// </summary>
        [StringLength(50)]
        public string PartnerIban { get; set; }

        /// <summary>
        /// Gets or sets specific symbol.
        /// </summary>
        [StringLength(10)]
        public string SpecificSymbol { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [StringLength(10)]
        [Required]
        public string VariableSymbol { get; set; }
    }
}
