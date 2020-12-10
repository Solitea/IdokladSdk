namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringInvoiceResultGetModel.
    /// </summary>
    public class RecurringInvoiceResultGetModel : RecurringInvoiceGetModel
    {
        /// <summary>
        /// Gets or sets created invoice. Invoice will be created if DateOfStart = current date, TypeOfEnd != 2 and CopyCountEnd != 0.
        /// </summary>
        public InvoiceFromRecurringInvoiceGetModel CreatedInvoice { get; set; }
    }
}
