using System;
using System.Collections.Generic;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;
using IdokladSdk.Models.SalesPosEquipment;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceGetModel.
    /// </summary>
    public class IssuedInvoiceGetModel : IssuedInvoiceListGetModel
    {
        /// <summary>
        /// Gets or sets constantSymbol.
        /// </summary>
        public ConstantSymbolGetModel ConstantSymbol { get; set; }

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
        /// Gets or sets list of Id of accounted proforma invoices.
        /// </summary>
        public List<int> ProformaInvoices { get; set; }

        /// <summary>
        /// Gets or sets salesPosEquipment.
        /// </summary>
        public SalesPosEquipmentGetModel SalesPosEquipment { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public new List<TagDocumentGetModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets vatReverseChargeCode.
        /// </summary>
        public VatReverseChargeCodeGetModel VatReverseChargeCode { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public new List<IssuedInvoiceItemGetModel> Items { get; set; }

        /// <summary>
        /// List of date taxing of issued tax documents
        /// </summary>
        public IList<DateTime> VatRatePeriods { get; set; }
    }
}
