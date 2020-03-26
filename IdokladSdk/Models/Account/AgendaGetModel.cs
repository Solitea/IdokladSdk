using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaGetModel.
    /// </summary>
    public class AgendaGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets list of bank accounts.
        /// </summary>
        public IEnumerable<BankAccountGetModel> BankAccounts { get; set; }

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
        /// Gets or sets eet regime.
        /// </summary>
        public EetRegime EetRegime { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether vAT payer indication.
        /// </summary>
        public bool IsRegisteredForVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether attribute for application of VAT based on payments.
        /// </summary>
        public bool IsRegisteredForVatOnPay { get; set; }

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
        /// Gets or sets default rounding type.
        /// </summary>
        public Round RoundingDifference { get; set; }

        /// <summary>
        /// Gets or sets current subscription.
        /// </summary>
        public SubscriptionGetModel Subscription { get; set; }

        /// <summary>
        /// Gets or sets vAT registration type.
        /// </summary>
        public VatRegistrationType VatRegistrationType { get; set; }
    }
}
