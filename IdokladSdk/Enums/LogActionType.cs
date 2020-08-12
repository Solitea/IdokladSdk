namespace IdokladSdk.Enums
{
    /// <summary>
    /// LogActionType.
    /// </summary>
    public enum LogActionType
    {
        /// <summary>
        /// Insert.
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Update.
        /// </summary>
        Update = 2,

        /// <summary>
        /// Delete.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// PaymentCreated.
        /// </summary>
        PaymentCreated = 4,

        /// <summary>
        /// PaymentDeleted.
        /// </summary>
        PaymentDeleted = 5,

        /// <summary>
        /// DocumentPrinted.
        /// </summary>
        DocumentPrinted = 6,

        /// <summary>
        /// DocumentExportedToPdf.
        /// </summary>
        DocumentExportedToPdf = 7,

        /// <summary>
        /// SentEmail.
        /// </summary>
        SentEmail = 8,

        /// <summary>
        /// PaymentConfirmation.
        /// </summary>
        PaymentConfirmation = 9,

        /// <summary>
        /// ReminderSent.
        /// </summary>
        ReminderSent = 10,

        /// <summary>
        /// ExportToAccountingSoftware.
        /// </summary>
        ExportToAccountingSoftware = 11,

        /// <summary>
        /// CancelExportedState.
        /// </summary>
        CancelExportedState = 12,

        /// <summary>
        /// ImportedFromSalesPosEquipment.
        /// </summary>
        ImportedFromSalesPosEquipment = 13,

        /// <summary>
        /// SalesReceiptAccounting.
        /// </summary>
        SalesReceiptAccounting = 15,

        /// <summary>
        /// SalesReceiptAccountingCanceled.
        /// </summary>
        SalesReceiptAccountingCanceled = 16,

        /// <summary>
        /// UnmarkAsDeleted.
        /// </summary>
        UnmarkAsDeleted = 17,

        /// <summary>
        /// DeliveryNotePrinted.
        /// </summary>
        DeliveryNotePrinted = 18,

        /// <summary>
        /// TaxReceiptForPaymentPrinted.
        /// </summary>
        TaxReceiptForPaymentPrinted = 19
    }
}
