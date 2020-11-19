using System.Collections.Generic;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DeliveryAddress;

namespace IdokladSdk.Models.Contact
{
    /// <summary>
    /// ContactListGetModel.
    /// </summary>
    public class ContactListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank id.
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets default discount percentage for the contact.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets e-mail address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets fax.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets iBAN.
        /// </summary>
        public string Iban { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the company's ID.
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether attribute for application of VAT based on payments
        /// Only for Sk legislation.
        /// </summary>
        public bool IsRegisteredForVatOnPay { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets mobile phone number.
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets area postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether send automatic reminders indication.
        /// </summary>
        public bool SendReminders { get; set; }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets swift code.
        /// </summary>
        public string Swift { get; set; }

        /// <summary>
        /// Gets or sets academic or other title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets vAT ID.
        /// </summary>
        public string VatIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets vAT ID.
        /// </summary>
        /// Only for Sk legislation
        public string VatIdentificationNumberSk { get; set; }

        /// <summary>
        /// Gets or sets the contact's website.
        /// </summary>
        public string Www { get; set; }

        /// <summary>
        /// Gets or sets the contact's note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets default invoice maturity.
        /// </summary>
        public short? DefaultInvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets delivery addresses.
        /// </summary>
        public List<DeliveryAddressGetModel> DeliveryAddresses { get; set; }
    }
}
