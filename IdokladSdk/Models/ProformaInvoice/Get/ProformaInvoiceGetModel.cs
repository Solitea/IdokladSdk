using System.Collections.Generic;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.SalesPosEquipment;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceGetModel.
        /// </summary>
    public class ProformaInvoiceGetModel : ProformaInvoiceListGetModel
    {
        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        public ConstantSymbolGetModel ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets sales pos equipment.
        /// </summary>
        public SalesPosEquipmentGetModel SalesPosEquipment { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public new List<ProformaInvoiceItemGetModel> Items { get; set; }
    }
}
