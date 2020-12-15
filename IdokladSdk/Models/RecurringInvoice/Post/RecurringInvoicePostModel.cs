using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringInvoicePostModel.
    /// </summary>
    public class RecurringInvoicePostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets invoice template for recurring invoice.
        /// </summary>
        [Required]
        public InvoiceTemplatePostModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets setting for recurring invoice.
        /// </summary>
        [Required]
        public RecurringSettingPostModel RecurringSetting { get; set; }
    }
}
