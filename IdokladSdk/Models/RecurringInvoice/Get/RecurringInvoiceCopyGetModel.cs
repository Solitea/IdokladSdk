namespace IdokladSdk.Models.RecurringInvoice.Get
{
    /// <summary>
    /// RecurringInvoiceCopyGetModel.
    /// </summary>
    public class RecurringInvoiceCopyGetModel
    {
        /// <summary>
        /// Gets or sets invoice template for recurring invoice.
        /// </summary>
        public InvoiceTemplateCopyGetModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets setting for recurring invoice.
        /// </summary>
        public RecurringSettingPostModel RecurringSetting { get; set; }
    }
}
