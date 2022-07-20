using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaGetModel.
    /// </summary>
    public class AgendaGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets a value indicating whether editing of exported documents is allowed.
        /// </summary>
        public bool AllowEditExported { get; set; }

        /// <summary>
        /// Gets or sets automatic pair payment settings.
        /// </summary>
        public AutomaticPairPaymentsSettingsGetModel AutomaticPairPaymentsSettings { get; set; }

        /// <summary>
        /// Gets or sets list of bank accounts.
        /// </summary>
        public IEnumerable<BankAccountGetModel> BankAccounts { get; set; }

        /// <summary>
        /// Gets or sets cash registers list.
        /// </summary>
        public IEnumerable<CashRegisterGetModel> CashRegisters { get; set; }

        /// <summary>
        /// Gets or sets contact information.
        /// </summary>
        public AgendaContactGetModel Contact { get; set; }

        /// <summary>
        /// Gets or sets default number of displayed decimals for amounts..
        /// </summary>
        public int CountOfDecimalsForAmount { get; set; }

        /// <summary>
        /// Gets or sets default number of displayed decimals for prices..
        /// </summary>
        public int CountOfDecimalsForPrice { get; set; }

        /// <summary>
        /// Gets or sets customer guid.
        /// </summary>
        public Guid? CswCustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets PIN for phone support.
        /// </summary>
        public string CswCustomerPin { get; set; }

        /// <summary>
        /// Gets or sets the agenda's default currency id.
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        /// Gets or sets default e-mail send method.
        /// </summary>
        public SendType DefaultSendMethod { get; set; }

        /// <summary>
        /// Gets or sets delete agenda status.
        /// </summary>
        public AgendaDeleteStatus DeleteStatus { get; set; }

        /// <summary>
        /// Gets or sets eet regime.
        /// </summary>
        public EetRegime EetRegime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether agenda has active web recurring payments.
        /// </summary>
        public bool HasActiveWebRecurringPayments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether VAT classification is used.
        /// </summary>
        public bool HasVatCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether OSS regime is set on agenda.
        /// </summary>
        public bool HasVatRegimeOss { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether subscription is paid on mobile device.
        /// </summary>
        public bool IsActiveStorePayment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether prices with VAT are shown.
        /// </summary>
        public bool IsPriceWithVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether agenda is VAT payer.
        /// </summary>
        public bool IsRegisteredForVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether application of VAT is based on payments.
        /// Only for SK legislation.
        /// </summary>
        public bool IsRegisteredForVatOnPay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether automatic payment confirmation is send.
        /// </summary>
        public bool IsSendPaymentConfirmation { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity..
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets company name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets preferred price type.
        /// </summary>
        public PriceType PreferredPriceType { get; set; }

        /// <summary>
        /// Gets or sets preferred VAT rate.
        /// </summary>
        public VatRateType PreferredVatRate { get; set; }

        /// <summary>
        /// Gets or sets purchase settings.
        /// </summary>
        public PurchaseSettingsGetModel PurchaseSettings { get; set; }

        /// <summary>
        /// Gets or sets register records.
        /// </summary>
        public string RegisterRecord { get; set; }

        /// <summary>
        /// Gets or sets default rounding type.
        /// </summary>
        public Round RoundingDifference { get; set; }

        /// <summary>
        /// Gets or sets sales settings.
        /// </summary>
        public SalesSettingsGetModel SalesSettings { get; set; }

        /// <summary>
        /// Gets or sets reminder sending settings.
        /// </summary>
        public SendReminderSettingsGetModel SendReminderSettings { get; set; }

        /// <summary>
        /// Gets or sets current subscription.
        /// </summary>
        public SubscriptionGetModel Subscription { get; set; }

        /// <summary>
        /// Gets or sets tax subject type.
        /// </summary>
        public TaxSubjectType TaxSubjectType { get; set; }

        /// <summary>
        /// Gets or sets taxing period.
        /// </summary>
        public VatPeriod VatPeriod { get; set; }

        /// <summary>
        /// Gets or sets vAT registration type.
        /// </summary>
        public VatRegistrationType VatRegistrationType { get; set; }
    }
}
