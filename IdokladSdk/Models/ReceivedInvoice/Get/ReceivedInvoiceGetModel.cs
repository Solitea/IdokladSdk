using System.Collections.Generic;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceGetModel.
    /// </summary>
    public class ReceivedInvoiceGetModel : ReceivedInvoiceListGetModel
    {
        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public new List<ReceivedInvoiceItemGetModel> Items { get; set; }

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
        /// Gets or sets vat reverse charge code.
        /// </summary>
        public VatReverseChargeCodeGetModel VatReverseChargeCode { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public new List<TagDocumentGetModel> Tags { get; set; }
    }
}
