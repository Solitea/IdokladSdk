namespace IdokladSdk.Models.RecurringInvoice.Get
{
    /// <summary>
    /// RecurringInvoiceCopyGetModel.
    /// </summary>
    public class RecurringInvoiceCopyGetModel
    {
        /// <summary>
        /// Gets or Sets Invoice template for recurring invoice.
        /// </summary>
        public InvoiceTemplateCopyGetModel InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or Sets Setting for recurring invoice.
        /// </summary>
        public RecurringSettingPostModel RecurringSetting { get; set; }
    }
}
