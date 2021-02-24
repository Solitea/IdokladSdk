using System.Collections.Generic;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.IssuedTaxDocument.List;
using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.IssuedTaxDocument.Get
{
    /// <summary>
    /// IssuedTaxDocumentGetModel.
    /// </summary>
    public class IssuedTaxDocumentGetModel : IssuedTaxDocumentListGetModel
    {
        /// <summary>
        /// Gets or sets Invoice by which Issued Tax Document is accounted.
        /// </summary>
        public IssuedInvoiceGetModel AccountedByInvoice { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets Issued tax document Items.
        /// </summary>
        public List<IssuedTaxDocumentItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets Partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets Payment.
        /// </summary>
        public IssuedDocumentPaymentGetModel Payment { get; set; }

        /// <summary>
        /// Gets or sets ProformaInvoice.
        /// </summary>
        public IssuedInvoiceGetModel ProformaInvoice { get; set; }
    }
}
