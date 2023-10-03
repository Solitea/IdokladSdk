using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// SalesSettingsPatchModel.
    /// </summary>
    public class SalesSettingsPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets default invoice maturity.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int? DefaultInvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets default price type.
        /// </summary>
        public PriceType? DefaultPriceType { get; set; }

        /// <summary>
        /// Gets or sets default VAT code ID.
        /// </summary>
        public NullableProperty<int> DefaultVatCodeId { get; set; }

        /// <summary>
        /// Gets or sets default VAT rate.
        /// </summary>
        public VatRateType? DefaultVatRate { get; set; }

        /// <summary>
        /// Gets or sets text preceding invoice items.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets text following invoice items.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets text preceding proforma invoice items.
        /// </summary>
        public string ProformaItemsPrefixText { get; set; }

        /// <summary>
        /// Gets or sets text following proforma invoice items.
        /// </summary>
        public string ProformaItemsSuffixText { get; set; }
    }
}
