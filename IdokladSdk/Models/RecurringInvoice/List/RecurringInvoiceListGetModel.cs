using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringInvoiceListGetModel.
    /// </summary>
    public class RecurringInvoiceListGetModel : IEntityId
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets invoice template for recurring invoice.
        /// </summary>
        public InvoiceTemplateListGetModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets setting for recurring invoice.
        /// </summary>
        public RecurringSettingListGetModel RecurringSetting { get; set; }
    }
}
