using System;

namespace IdokladSdk.Models.ReadOnly.Country
{
    /// <summary>
    /// CountryListGetModel.
    /// </summary>
    public class CountryListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets iSO ALPHA-3 country code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was last changed.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the country is member of the European Union.
        /// </summary>
        public bool IsEuMember { get; set; }

        /// <summary>
        /// Gets or sets czech name of country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets english name of country.
        /// </summary>
        public string NameEnglish { get; set; }

        /// <summary>
        /// Gets or sets german name of country.
        /// </summary>
        public string NameGerman { get; set; }

        /// <summary>
        /// Gets or sets slovak name of country.
        /// </summary>
        public string NameSlovak { get; set; }
    }
}
