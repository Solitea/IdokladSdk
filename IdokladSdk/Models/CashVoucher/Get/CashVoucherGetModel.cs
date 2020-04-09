using System.Collections.Generic;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.RegisteredSale;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// GET model for CashVoucher.
    /// </summary>
    public class CashVoucherGetModel : CashVoucherListGetModel
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
        /// Gets or sets cash reagister.
        /// </summary>
        public CashRegisterGetModel CashRegister { get; set; }

        /// <summary>
        /// Gets or sets registered sale.
        /// </summary>
        public new RegisteredSaleGetModel RegisteredSale { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public new List<TagDocumentGetModel> Tags { get; set; }
    }
}
