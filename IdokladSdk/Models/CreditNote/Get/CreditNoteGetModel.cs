using System;
using System.Collections.Generic;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteGetModel.
    /// </summary>
    public class CreditNoteGetModel : CreditNoteListGetModel
    {
        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        public ConstantSymbolGetModel ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets credited invoice.
        /// </summary>
        public IssuedInvoiceGetModel CreditedInvoice { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public new List<CreditNoteItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public new List<TagDocumentGetModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge code id.
        /// </summary>
        public VatReverseChargeCodeGetModel VatReverseChargeCode { get; set; }

        /// <summary>
        /// List of date taxing of issued tax documents for credited invoice.
        /// </summary>
        public IList<DateTime> VatRatePeriods { get; set; }
    }
}
