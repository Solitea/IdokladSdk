using IdokladSdk.Enums;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringInvoiceResultGetModel.
    /// </summary>
    public class RecurringInvoiceResultGetModel : RecurringInvoiceGetModel
    {
        /// <summary>
        /// Gets or sets created invoice. Invoice will be created if DateOfStart = current date, TypeOfEnd != <see cref="RecurrenceTypeOfEnd.AfterNumberCreated"/> and CopyCountEnd != 0.
        /// </summary>
        public InvoiceFromRecurringInvoiceGetModel CreatedInvoice { get; set; }
    }
}
