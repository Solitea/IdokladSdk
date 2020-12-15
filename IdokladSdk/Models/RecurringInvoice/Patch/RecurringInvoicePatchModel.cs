using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringInvoicePatchModel.
    /// </summary>
    public class RecurringInvoicePatchModel : ValidatableModel, IEntityId
    {
        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets invoice template for recurring invoice.
        /// </summary>
        public InvoiceTemplatePatchModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets setting for recurring invoice.
        /// </summary>
        public RecurringSettingPatchModel RecurringSetting { get; set; }
    }
}
