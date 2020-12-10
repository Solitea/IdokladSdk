using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceItemTemplatePatchModel.
    /// </summary>
    public class InvoiceItemTemplatePatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <inheritdoc cref="IEntityId.Id"/>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item Id.
        /// </summary>
        public NullableProperty<int> PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType? PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets VAT code Id.
        /// </summary>
        public NullableProperty<int> VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
