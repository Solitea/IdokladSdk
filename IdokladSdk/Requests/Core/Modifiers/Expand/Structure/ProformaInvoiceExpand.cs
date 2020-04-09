using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ProformaInvoiceExpand.
    /// </summary>
    public class ProformaInvoiceExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactExpand Partner { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        public ConstantSymbolExpand ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets sales pos equipment.
        /// </summary>
        public SalesPosEquipmentExpand SalesPosEquipment { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public TagsExpand Tags { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public ProformaInvoiceItemExpand Items { get; set; }
    }
}
