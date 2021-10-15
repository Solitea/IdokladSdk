using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.IssuedTaxDocument.Get
{
    /// <summary>
    /// IssuedTaxDocumentItemGetModel.
    /// </summary>
    public class IssuedTaxDocumentItemGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Prices.
        /// </summary>
        public TaxDocumentItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets PriceType.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets VatCodeId.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VatRate.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets VatRateType.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
