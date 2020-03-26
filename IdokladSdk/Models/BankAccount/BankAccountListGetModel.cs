using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.BankAccount
{
    /// <summary>
    /// BankAccountListGetModel.
    /// </summary>
    public class BankAccountListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank id.
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public virtual int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets iban.
        /// </summary>
        [StringLength(50)]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets bank account name.
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether bank account is default.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets swift.
        /// </summary>
        [StringLength(11)]
        public string Swift { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
