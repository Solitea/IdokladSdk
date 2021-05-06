using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// AccountProformaInvoicesPutModel.
    /// </summary>
    public class AccountProformaInvoicesPutModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets ids of proforma invoices.
        /// </summary>
        [Required]
        public IEnumerable<int> ProformaIds { get; set; }
    }
}
