namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaContactGetModel.
    /// </summary>
    public class AgendaContactGetModel
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets e-mail address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets fax.
        /// </summary>
        public string Fax { get; set; }

        /// <summary xml:lang="en">
        /// Gets or sets a value indicating whether the company ID flag indication
        /// </summary>
        public bool HasNoIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets the company's ID.
        /// </summary>
        public string IdentificationNumber { get; set; }

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
        /// Gets or sets street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets VAT ID.
        /// </summary>
        public string VatIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets VAT ID.
        /// Only for SK legislation.
        /// </summary>
        public string VatIdentificationNumberSk { get; set; }

        /// <summary>
        /// Gets or sets the contact's website.
        /// </summary>
        public string Www { get; set; }
    }
}
