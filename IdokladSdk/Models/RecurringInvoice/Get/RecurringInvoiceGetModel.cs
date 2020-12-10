namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringInvoiceGetModel.
    /// </summary>
    public class RecurringInvoiceGetModel : RecurringInvoiceListGetModel
    {
        /// <summary>
        /// Gets or sets invoice template for recurring invoice.
        /// </summary>
        public new InvoiceTemplateGetModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets setting for recurring invoice.
        /// </summary>
        public new RecurringSettingGetModel RecurringSetting { get; set; }
    }
}
