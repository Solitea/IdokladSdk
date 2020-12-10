using System.Collections.Generic;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceTemplateGetModel.
    /// </summary>
    public class InvoiceTemplateGetModel : InvoiceTemplateListGetModel
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
        /// Gets or sets invoice items.
        /// </summary>
        public new List<InvoiceItemTemplateGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        public ConstantSymbolGetModel ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge code.
        /// </summary>
        public VatReverseChargeCodeGetModel VatReverseChargeCode { get; set; }
    }
}
