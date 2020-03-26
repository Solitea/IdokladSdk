namespace IdokladSdk.Enums
{
    /// <summary>
    /// Error codes specific to iDoklad.
    /// </summary>
    public enum DokladErrorCode
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// System error
        /// </summary>
        System = 500,

        /// <summary>
        /// Bad format error.
        /// </summary>
        BadFormat = 400,

        /// <summary>
        /// Billing error
        /// </summary>
        Billing = 600,

        /// <summary>
        /// Invoice dependency
        /// </summary>
        InvoiceDependency = 101,

        /// <summary>
        /// Cash voucher dependency
        /// </summary>
        CashVoucherDependency = 102,

        /// <summary>
        /// Bank statement item dependency
        /// </summary>
        BankStatementItemDependency = 103,

        /// <summary>
        /// Accounted proforma dependency
        /// </summary>
        AccountedProformaDependency = 104,

        /// <summary>
        /// Credit notes dependency
        /// </summary>
        CreditNotesDependency = 105,

        /// <summary>
        /// Payments dependency
        /// </summary>
        PaymentsDependency = 106,

        /// <summary>
        /// Export error
        /// </summary>
        Export = 107,

        /// <summary>
        /// Imported
        /// </summary>
        Imported = 108,

        /// <summary>
        /// Is registered
        /// </summary>
        IsRegistered = 109,

        /// <summary>
        /// Credit note has already been paid
        /// </summary>
        CreditNoteHasAlreadyBeenPaid = 110,

        /// <summary>
        /// Unpaid amount of the invoice is less than amount of the credit note or credit note currency and invoice currency differ
        /// </summary>
        CreditNoteOffsetFailed = 111
    }
}
