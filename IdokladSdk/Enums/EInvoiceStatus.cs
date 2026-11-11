namespace IdokladSdk.Enums
{
    /// <summary>
    /// Overall delivery status of an electronic invoice.
    /// </summary>
    public enum EInvoiceStatus : byte
    {
        /// <summary>Default status.</summary>
        Default = 0,

        /// <summary>Document was accepted.</summary>
        Accepted = 1,

        /// <summary>Document was sent.</summary>
        Sent = 2,

        /// <summary>Document was confirmed by the recipient.</summary>
        ReceiveConfirmed = 3,

        /// <summary>Document was delivered.</summary>
        Delivered = 4,

        /// <summary>Document delivery failed.</summary>
        Failed = 5,

        /// <summary>The recipient was not found.</summary>
        ReceiverNotFound = 6,
    }
}
