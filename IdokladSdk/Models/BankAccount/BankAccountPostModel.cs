using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankAccount
{
    /// <summary>
    /// BankAccountPostModel.
    /// </summary>
    public class BankAccountPostModel
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank Id.
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date when the initial state was set.
        /// </summary>
        [RequiredIfHasValue(nameof(InitialState))]
        [DateTime]
        public DateTime? DateInitialState { get; set; }

        /// <summary>
        /// Gets or sets IBAN.
        /// </summary>
        [StringLength(50)]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets initial amount of money in the bank account.
        /// </summary>
        [RequiredIfHasValue(nameof(DateInitialState))]
        public decimal? InitialState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether bank account is default.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets bank account name.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Swift code.
        /// </summary>
        [StringLength(11)]
        public string Swift { get; set; }
    }
}
