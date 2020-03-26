using System.Collections.Generic;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.SalesPosEquipment;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceipt Model for Get endpoints.
    /// </summary>
    public class SalesReceiptGetModel : SalesReceiptListGetModel
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
        /// Gets or sets salesPosEquipment.
        /// </summary>
        public SalesPosEquipmentGetModel SalesPosEquipment { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public new List<SalesReceiptItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payments.
        /// </summary>
        public new List<SalesReceiptPaymentGetModel> Payments { get; set; }
    }
}
