namespace IdokladSdk.Enums
{
    /// <summary>
    /// Detailed delivery state of an electronic invoice.
    /// </summary>
    public enum EInvoiceState : byte
    {
        /// <summary>State does not apply.</summary>
        NotApplicable = 0,

        /// <summary>Document is waiting to be sent.</summary>
        PendingSend = 1,

        /// <summary>Sending is overdue.</summary>
        Overdue = 2,

        /// <summary>XML was downloaded.</summary>
        XmlDownloaded = 10,

        /// <summary>Email was sent.</summary>
        EmailSent = 21,

        /// <summary>Email was viewed.</summary>
        EmailViewed = 23,

        /// <summary>Document was sent to Peppol.</summary>
        SentToPeppol = 31,

        /// <summary>Peppol delivery failed or awaits retry.</summary>
        PeppolErrorOrPendingRetry = 32,

        /// <summary>Document was delivered through Peppol.</summary>
        DeliveredToPeppol = 33
    }
}
