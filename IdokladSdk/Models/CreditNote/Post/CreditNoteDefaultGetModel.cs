using System;
using System.Collections.Generic;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.CreditNote.Post
{
    /// <summary>
    /// CreditNoteDefaultGetModel.
    /// </summary>
    public class CreditNoteDefaultGetModel : CreditNotePostModel
    {
        /// <summary>
        /// Gets or sets date of taxing credited invoice.
        /// </summary>
        public DateTime DateOfTaxingCreditedInvoice { get; set; }

        /// <summary>
        /// Gets or sets discount type.
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }

        /// <summary>
        /// List of date taxing of issued tax documents
        /// </summary>
        public IList<DateTime> VatRatePeriods { get; set; }
    }
}
