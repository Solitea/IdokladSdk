﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DeliveryAddress;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Contact
{
    /// <summary>
    /// PathModel for Contact.
    /// </summary>
    public class ContactPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        [BankAccountNumber]
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
        /// Gets or sets company name.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> CountryId { get; set; }

        /// <summary>
        /// Gets or sets default invoice maturity.
        /// </summary>
        public NullableProperty<short> DefaultInvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets delivery addresses.
        /// </summary>
        public List<DeliveryAddressPatchModel> DeliveryAddresses { get; set; }

        /// <summary>
        /// Gets or sets default discount percentage for the contact.
        /// </summary>
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets e-mail address.
        /// </summary>
        [StringLength(254)]
        [DataType(DataType.EmailAddress)]
        [Email]
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

        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the company's ID.
        /// </summary>
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets attribute for application of VAT based on payments.
        /// Only for Sk legislation.
        /// </summary>
        public bool? IsRegisteredForVatOnPay { get; set; }

        /// <summary>
        /// Gets or sets mobile phone number.
        /// </summary>
        [StringLength(20)]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the contact's note.
        /// </summary>
        public string Note { get; set; }

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
        /// Gets or sets send automatic reminders indication.
        /// </summary>
        public bool? SendReminders { get; set; }

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
        /// Only for Sk legislation.
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
