namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// Changes to agenda settings for electronic invoice attachments under Slovak legislation.
    /// </summary>
    public class AgendaEInvoicePatchModel
    {
        /// <summary>Gets or sets a value indicating whether all attachments are sent with the electronic invoice.</summary>
        public bool? IncludeAllAttachments { get; set; }

        /// <summary>Gets or sets a value indicating whether the document PDF is sent with the electronic invoice.</summary>
        public bool? IsSelfPdfIncludeEnabled { get; set; }
    }
}
