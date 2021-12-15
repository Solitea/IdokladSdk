using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankAccount
{
    /// <summary>
    /// BankAccountPatchModel.
    /// </summary>
    public class BankAccountPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        [BankAccountNumber]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank Id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> BankId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int? CurrencyId { get; set; }

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
        [Iban]
        public string Iban { get; set; }

        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets initial amount of money in the bank account.
        /// </summary>
        [RequiredIfHasValue(nameof(DateInitialState))]
        public decimal? InitialState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether bank account is default.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets bank account name.
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets SWIFT code.
        /// </summary>
        [StringLength(11)]
        public string Swift { get; set; }
    }
}
