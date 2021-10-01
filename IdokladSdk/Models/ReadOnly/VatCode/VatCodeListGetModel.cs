using System;
using IdokladSdk.Enums;

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
        /// Gets or sets filter according to partner's country.
        /// </summary>
        public VatCodeFilterPartner CountryType { get; set; }

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
        /// Gets or sets a value indicating whether VAT code is available in OSS mode.
        /// </summary>
        public bool Moss { get; set; }

        /// <summary>
        /// Gets or sets VAT classification name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets reverse charge mode.
        /// </summary>
        public ReverseChargeType ReverseChargeType { get; set; }

        /// <summary>
        /// Gets or sets VAT movement type.
        /// </summary>
        public VatMovementType VatMovementType { get; set; }

        /// <summary>
        /// Gets or sets VAT return row.
        /// </summary>
        public string VatReturnRow { get; set; }
    }
}
