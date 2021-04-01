namespace IdokladSdk.Enums
{
    /// <summary>
    /// NotificationType.
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Customer support response
        /// </summary>
        Support = 0,

        /// <summary>
        /// Pairing of bank transactions
        /// </summary>
        BankStatement = 1,

        /// <summary>
        /// Invoice displayed by the customer
        /// </summary>
        DocumentLinkActivated = 3,

        /// <summary>
        /// Automatic reminder sending has been blocked
        /// </summary>
        RemindersDisabled = 4,

        /// <summary>
        /// The VAT payer limit has been reached
        /// </summary>
        VatPayerLimitReached = 5,

        /// <summary>
        /// API request limit warning
        /// </summary>
        ApiLimit = 7,

        /// <summary>
        /// Automatically issued invoice
        /// </summary>
        RecurringInvoice = 9,

        /// <summary>
        /// Automatic invoice reminder
        /// </summary>
        RemindedInvoice = 10,

        /// <summary>
        /// News in application (not available via iDoklad API)
        /// </summary>
        NewsInApplication = 11,

        /// <summary>
        /// Payment of the subscription (not available via iDoklad API)
        /// </summary>
        OfflinePayment = 12,

        /// <summary>
        /// Referral points expiration
        /// </summary>
        ReferralExpiredSoon = 13,

        /// <summary>
        /// Discount code expiration
        /// </summary>
        ReferralPromoCodeExpiredSoon = 14,

        /// <summary>
        /// Points has been added to your reward program
        /// </summary>
        ReferralPointsManual = 15,

        /// <summary>
        /// Automatic subscription renewal failed
        /// </summary>
        RecurringOrder = 16,

        /// <summary>
        /// EET certificate expiration
        /// </summary>
        EetCertificate = 17,

        /// <summary>
        /// Documents not registered in the EET
        /// </summary>
        EetUnregisteredSales = 18,

        /// <summary>
        /// General message (not available via iDoklad API)
        /// </summary>
        CustomMessage = 19,

        /// <summary>
        /// Non accounted payment of proforma invoice
        /// </summary>
        ProformaPaymentNotAccounted = 20
    }
}
