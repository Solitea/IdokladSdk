namespace IdokladSdk.Models.RecurringInvoice.Get
{
    /// <summary>
    /// RecurringInvoiceFromInvoiceGetModel.
    /// </summary>
    public class RecurringInvoiceFromInvoiceGetModel
    {
        /// <summary>
        /// Gets or sets invoice template for recurring invoice.
        /// </summary>
        public InvoiceTemplatePostModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets setting for recurring invoice.
        /// </summary>
        public RecurringSettingPostModel RecurringSetting { get; set; }
    }
}
