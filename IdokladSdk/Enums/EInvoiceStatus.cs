namespace IdokladSdk.Enums
{
    /// <summary>
    /// Overall delivery status of an electronic invoice.
    /// </summary>
    public enum EInvoiceStatus : byte
    {
        /// <summary>Default status.</summary>
        Default = 0,

        /// <summary>Document was sent.</summary>
        Sent = 1,

        /// <summary>Document was sent but delivery failed.</summary>
        SentWithErrorOnDelivery = 2,

        /// <summary>Document was delivered.</summary>
        Delivered = 3
    }
}
