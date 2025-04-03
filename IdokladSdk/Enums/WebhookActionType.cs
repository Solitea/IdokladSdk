namespace IdokladSdk.Enums
{
    /// <summary>
    /// WebhookActionType.
    /// </summary>
    public enum WebhookActionType : byte
    {
        /// <summary>
        /// Insert entity
        /// </summary>
        Insert = LogActionType.Insert,

        /// <summary>
        /// Update entity
        /// </summary>
        Update = LogActionType.Update,

        /// <summary>
        /// Delete entity
        /// </summary>
        Delete = LogActionType.Delete,

        /// <summary>
        /// Payment created
        /// </summary>
        PaymentCreated = LogActionType.PaymentCreated,

        /// <summary>
        /// Payment deleted
        /// </summary>
        PaymentDeleted = LogActionType.PaymentDeleted,

        /// <summary>
        /// Sales receipt accounting
        /// </summary>
        SalesReceiptAccounting = LogActionType.SalesReceiptAccounting,

        /// <summary>
        /// Sales receipt accounting canceled
        /// </summary>
        SalesReceiptAccountingCanceled = LogActionType.SalesReceiptAccountingCanceled,

        /// <summary>
        /// Unmark entity as deleted
        /// </summary>
        UnmarkAsDeleted = LogActionType.UnmarkAsDeleted,
    }
}
