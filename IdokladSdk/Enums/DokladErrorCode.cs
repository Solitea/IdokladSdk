﻿namespace IdokladSdk.Enums
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
        /// Numeric sequence must be unique.
        /// </summary>
        NumericSequenceUniqueness = 123,

        /// <summary>
        /// Exceeded allowed daily registration count.
        /// </summary>
        RegistrationExceeded = 124,

        /// <summary>
        /// Registration email domain in blacklist.
        /// </summary>
        RegistrationForbidden = 125,

        /// <summary>
        /// Using iDoklad API is forbidden.
        /// </summary>
        ApiForbidden = 126,

        /// <summary>
        /// Vat rate type not fond.
        /// </summary>
        VatRateType = 127,

        /// <summary>
        /// Update is not allowed if proforma invoice is already accounted.
        /// </summary>
        UpdateProformaAlreadyAccounted = 128,

        /// <summary>
        /// Update is not allowed for already paid invoices.
        /// </summary>
        UpdateProformaAlreadyPaid = 129,

        /// <summary>
        /// Update is not allowed if payment has a tax document for payment issued for it.
        /// </summary>
        UpdateProformaHasTaxDocuments = 130,

        /// <summary>
        /// Delete is not allowed if proforma invoice is already accounted.
        /// </summary>
        DeleteProformaAlreadyAccounted = 131,

        /// <summary>
        /// Delete id not allowed if payment has a tax document for payment issued for it.
        /// </summary>
        DeleteProformaHasTaxDocuments = 132,

        /// <summary>
        /// Post is not allowed if proforma invoice is already accounted.
        /// </summary>
        PostProformaAlreadyAccounted = 133,

        /// <summary>
        /// Put is not allowed if proforma invoice is already accounted.
        /// </summary>
        PutProformaAlreadyAccounted = 134,

        /// <summary>
        /// Put is not allowed if payment has a tax document for payment issued for it.
        /// </summary>
        PutProformaHasTaxDocuments = 135,

        /// <summary>
        /// Update is not allowed. Cannot be paired with another document.
        /// </summary>
        UpdateCashVoucherFromSalesReceipt = 136,

        /// <summary>
        /// Pairing is not allowed. Proforma Invoice is already accounted.
        /// </summary>
        PairRestricted_ProformaAlreadyAccounted = 137,

        /// <summary>
        /// Pairing is not allowed. Proforma Invoice has Issued Tax Document.
        /// </summary>
        PairRestricted_ProformaHasTaxDocuments = 138,

        /// <summary>
        /// Pairing is not allowed. Document is already paid.
        /// </summary>
        PairRestricted_DocumentIsPaid = 139,

        /// <summary>
        /// Pairing is not allowed. Document is deleted.
        /// </summary>
        PairRestricted_DocumentIsDeleted = 140,

        /// <summary>
        /// Pairing is not allowed. Document has different currency other than cash register or bank account.
        /// </summary>
        PairRestricted_DocumentHasDifferentCurrency = 141,

        /// <summary>
        /// Only certain properties are allowed to be patched for this model.
        /// </summary>
        UpdateRestrictedNotAllowedProperties = 142,

        /// <summary>
        /// No cash register has been found for given currency Id.
        /// </summary>
        NoCashRegisterFoundForCurrency = 143,

        /// <summary>
        /// No bank account has been found for given currency Id.
        /// </summary>
        NoBankAccountFoundForCurrency = 144,

        /// <summary>
        /// Pairing forbidden. Document is already paired.
        /// </summary>
        PairRestrictedDocumentIsPaired = 145,

        /// <summary>
        /// Pairing forbidden. Total price does not match with paired document.
        /// </summary>
        PairRestrictedTotalDoesNotMatch = 146,

        /// <summary>
        /// Pairing forbidden. Document must have one item.
        /// </summary>
        PairRestrictedNotExactlyOneItem = 147,

        /// <summary>
        /// CustomVat is available only for MovementType Issue.
        /// </summary>
        CustomVatRestriction = 148,

        /// <summary>
        /// Reduced items are not allowed to change.
        /// </summary>
        UpdateRestrictedReducedItems = 149,

        /// <summary>
        /// Contains unsupported vat rates with positive total sum.
        /// </summary>
        UnsupportedVatRateWithPositiveSum = 150,

        /// <summary>
        /// Conflict with vat rate and date for vat rate.
        /// </summary>
        ConflictVatRateAndDate = 151,
    }
}
