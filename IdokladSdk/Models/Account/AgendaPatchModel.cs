using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaPatchModel.
    /// </summary>
    public class AgendaPatchModel
    {
        /// <summary>
        /// Gets or sets automatic pair payment settings.
        /// </summary>
        public AutomaticPairPaymentsSettingsPatchModel AutomaticPairPaymentsSettings { get; set; }

        /// <summary>
        /// Gets or sets contact information.
        /// </summary>
        public AgendaContactPatchModel Contact { get; set; }

        /// <summary>
        /// Gets or sets default e-mail send method.
        /// </summary>
        public SendType? DefaultSendMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether VAT classification is used.
        /// </summary>
        public bool? HasVatCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether prices with VAT are shown.
        /// </summary>
        public bool? IsPriceWithVat { get; set; }

        /// <summary>
        /// Gets or sets attribute for application of VAT based on payments.
        /// Only for Sk legislation.
        /// </summary>
        public bool? IsRegisteredForVatOnPay { get; set; }

        /// <summary>
        /// Gets or sets automatic send payment confirmation.
        /// </summary>
        public bool? IsSendPaymentConfirmation { get; set; }

        /// <summary>
        /// Gets or sets company name.
        /// </summary>
        [NotEmptyString]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets purchase settings.
        /// </summary>
        public PurchaseSettingsPatchModel PurchaseSettings { get; set; }

        /// <summary>
        /// Gets or sets register records.
        /// </summary>
        public string RegisterRecord { get; set; }

        /// <summary>
        /// Gets or sets default rounding type.
        /// </summary>
        public Round? RoundingDifference { get; set; }

        /// <summary>
        /// Gets or sets sales settings.
        /// </summary>
        public SalesSettingsPatchModel SalesSettings { get; set; }

        /// <summary>
        /// Gets or sets reminder sending settings.
        /// </summary>
        public SendReminderSettingsPatchModel SendReminderSettings { get; set; }

        /// <summary>
        /// Gets or sets tax subject type.
        /// </summary>
        public TaxSubjectType? TaxSubjectType { get; set; }

        /// <summary>
        /// Gets or sets VAT registration type.
        /// </summary>
        public VatRegistrationType? VatRegistrationType { get; set; }
    }
}
