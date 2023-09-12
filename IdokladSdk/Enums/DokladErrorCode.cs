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
        /// Insufficient rights.
        /// </summary>
        UserRights = 420,

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
        /// Document has already been paid
        /// </summary>
        AlreadyPaid = 110,

        /// <summary>
        /// Offset conditions not met
        /// </summary>
        OffsetNotPossible = 111,

        /// <summary>
        /// Document has already been accounted
        /// </summary>
        AlreadyAccounted = 112,

        /// <summary>
        /// Document has not been paid
        /// </summary>
        NotPaid = 113,

        /// <summary>
        /// The entity is linked to the recurring invoice.
        /// </summary>
        RecurringInvoicesDependency = 114,

        /// <summary>
        /// The entity is linked to the issued document template.
        /// </summary>
        IssuedDocumentTemplateDependency = 115,

        /// <summary>
        /// Sending of email failed.
        /// </summary>
        SendMailFailed = 116,

        /// <summary>
        /// Cash register deletion failed.
        /// </summary>
        SalesPosEquipmentDependency = 117,

        /// <summary>
        /// Error regarding OSS regime. See exception message for more details.
        /// </summary>
        OssRegime = 119,

        /// <summary>
        /// Attachment maximum count has been exceeded.
        /// </summary>
        MaxAttachmentsCount = 120,

        /// <summary>
        /// Referral invoice cannot be updated.
        /// </summary>
        ReferralInvoice = 121,

        /// <summary>
        /// The daily email send limit has been exceeded.
        /// </summary>
        MailThreshold = 122,

        /// <summary>
        /// Numeric sequence must be unique
        /// </summary>
        NumericSequenceUniqueness = 123
    }
}
