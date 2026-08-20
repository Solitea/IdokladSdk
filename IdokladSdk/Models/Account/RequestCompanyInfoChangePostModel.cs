using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// RequestCompanyInfoChangePostModel.
    /// </summary>
    public class RequestCompanyInfoChangePostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets Company name.
        /// </summary>
        [Required]
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets City of residence.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets he company ID flag indication.
        /// </summary>
        [Required]
        public bool HasNoIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets The company's ID.
        /// </summary>
        [RequiredIf(nameof(HasNoIdentificationNumber), false)]
        [IdentificationNumberPost(nameof(HasNoIdentificationNumber))]
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets Area postal code.
        /// </summary>
        [Required]
        [StringLength(11)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets Street.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets VAT ID.
        /// </summary>
        [VatIdentificationNumber]
        public string VatIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets VAT ID.
        /// </summary>
        [StringLength(20)]
        public string VatIdentificationNumberSk { get; set; }

        /// <summary>
        /// Gets or sets Register records.
        /// </summary>
        [StringLength(250)]
        public string RegisterRecord { get; set; }

        /// <summary>
        /// Gets or sets VAT registration type.
        /// </summary>
        [Required]
        public VatRegistrationType VatRegistrationType { get; set; }

        /// <summary>
        /// Gets or sets Password for confirmation of changes.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
