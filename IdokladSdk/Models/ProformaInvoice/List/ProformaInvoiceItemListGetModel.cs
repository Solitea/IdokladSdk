using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceItemListGetModel.
    /// </summary>
    public class ProformaInvoiceItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item code.
        /// </summary>
        public string Code { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the item a tax movement indication.
        /// </summary>
        public bool IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public IssuedInvoiceItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets pricelist item id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets id členení DPH.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vAT rate in percent.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
