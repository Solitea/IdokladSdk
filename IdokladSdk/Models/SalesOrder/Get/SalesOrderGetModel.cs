using System.Collections.Generic;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrder Model for Get endpoints.
    /// </summary>
    public class SalesOrderGetModel : SalesOrderListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets paymentOption.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets sales order items.
        /// </summary>
        public new List<SalesOrderItemGetModel> Items { get; set; }
    }
}
