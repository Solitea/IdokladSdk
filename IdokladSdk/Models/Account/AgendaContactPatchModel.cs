using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaContactPatchModel.
    /// </summary>
    public class AgendaContactPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets fax.
        /// </summary>
        [StringLength(20)]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the company's ID.
        /// </summary>
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

        /// <summary xml:lang="en">
        /// Gets or sets the company ID flag indication
        /// </summary>
        public bool? HasNoIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets mobile phone number.
        /// </summary>
        [StringLength(20)]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets area postal code.
        /// </summary>
        [StringLength(11)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        [StringLength(100)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets VAT ID.
        /// </summary>
        [RegularExpression("(CZ|SK){1}[0-9]{8,10}", ErrorMessage = "The VAT ID is not in the right format.")]
        public string VatIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets VAT ID.
        /// Only for SK legislation.
        /// </summary>
        [StringLength(10)]
        public string VatIdentificationNumberSk { get; set; }

        /// <summary>
        /// Gets or sets the contact's website.
        /// </summary>
        [StringLength(50)]
        public string Www { get; set; }
    }
}
