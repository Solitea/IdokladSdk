using System;
using System.Collections.Generic;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class IssuedInvoiceDefaultGetModel : IssuedInvoicePostModel
    {
        /// <summary>
        /// Gets or sets List of date taxing of issued tax documents.
        /// </summary>
        public IList<DateTime> VatRatePeriods { get; set; }

        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
