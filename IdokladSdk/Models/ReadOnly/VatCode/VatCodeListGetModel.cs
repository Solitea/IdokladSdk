using System;

namespace IdokladSdk.Models.ReadOnly.VatCode
{
    /// <summary>
    /// VatCodeGetModel.
    /// </summary>
    public class VatCodeListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets date since the code is valid.
        /// </summary>
        public DateTime DateValidityFrom { get; set; }

        /// <summary>
        /// Gets or sets date until the code is valid.
        /// </summary>
        public DateTime DateValidityTo { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code in accounting software Money S3.
        /// </summary>
        public string MoneyS3Code { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code in accounting software Money S5.
        /// </summary>
        public string MoneyS5Code { get; set; }

        /// <summary>
        /// Gets or sets VAT classification name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets VAT return row.
        /// </summary>
        public string VatReturnRow { get; set; }
    }
}
