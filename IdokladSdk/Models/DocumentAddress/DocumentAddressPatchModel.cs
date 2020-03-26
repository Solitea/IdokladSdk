using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.DocumentAddress
{
    /// <summary>
    /// DocumentAddressPatchModel.
    /// </summary>
    public class DocumentAddressPatchModel
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> BankId { get; set; }

        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets nickname/name.
        /// </summary>
        [StringLength(200)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        [NullableForeignKey]
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets e-mail address.
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets fax.
        /// </summary>
        [StringLength(20)]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [StringLength(50)]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets iBAN.
        /// </summary>
        [StringLength(50)]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets the company's ID.
        /// </summary>
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

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
        /// Gets or sets last name.
        /// </summary>
        [StringLength(50)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets swift code.
        /// </summary>
        [StringLength(11)]
        public string Swift { get; set; }

        /// <summary>
        /// Gets or sets academic or other title.
        /// </summary>
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets vAT ID.
        /// </summary>
        [StringLength(20)]
        public string VatIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets vAT ID.
        /// </summary>
        [StringLength(20)]
        public string VatIdentificationNumberSk { get; set; }

        /// <summary>
        /// Gets or sets the contact's website.
        /// </summary>
        [StringLength(50)]
        public string Www { get; set; }
    }
}
