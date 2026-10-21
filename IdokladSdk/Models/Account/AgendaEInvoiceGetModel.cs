namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// Agenda settings for attachments sent with electronic invoices under Slovak legislation.
    /// </summary>
    public class AgendaEInvoiceGetModel
    {
        /// <summary>Gets or sets a value indicating whether all attachments are sent with the electronic invoice.</summary>
        public bool IncludeAllAttachments { get; set; }

        /// <summary>Gets or sets a value indicating whether the document PDF is sent with the electronic invoice.</summary>
        public bool IsSelfPdfIncludeEnabled { get; set; }
    }
}
