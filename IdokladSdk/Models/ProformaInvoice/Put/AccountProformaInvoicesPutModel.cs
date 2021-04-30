using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.ProformaInvoice.Put
{
    /// <summary>
    /// AccountProformaInvoicesPutModel.
    /// </summary>
    public class AccountProformaInvoicesPutModel : ValidatableModel
    {
        /// <summary>
        /// Gets or Sets Ids of proforma invoices.
        /// </summary>
        [Required]
        public IEnumerable<int> ProformaIds { get; set; }
    }
}
