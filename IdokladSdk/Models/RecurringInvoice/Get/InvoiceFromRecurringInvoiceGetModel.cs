using IdokladSdk.Enums;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceFromRecurringInvoiceGetModel.
    /// </summary>
    public class InvoiceFromRecurringInvoiceGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public RecurringDocumentType DocumentType { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }
    }
}
