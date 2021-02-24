using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// IssuedTaxDocumentExpand.
    /// </summary>
    public class IssuedTaxDocumentExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets Invoice by which Issued Tax Document is accounted.
        /// </summary>
        public IssuedInvoiceExpand AccountedByInvoice { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets Partner.
        /// </summary>
        public ContactExpand Partner { get; set; }

        /// <summary>
        /// Gets or sets Payment.
        /// </summary>
        public IssuedDocumentPaymentExpand Payment { get; set; }

        /// <summary>
        /// Gets or sets ProformaInvoice.
        /// </summary>
        public IssuedInvoiceExpand ProformaInvoice { get; set; }
    }
}
