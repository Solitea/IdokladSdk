using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// My subscription get model.
    /// </summary>
    public class MySubscriptionGetModel
    {
        /// <summary>
        /// Gets or sets Invoice guid.
        /// </summary>
        public Guid? CswInvoiceGuid { get; set; }

        /// <summary>
        /// Gets or sets Invoice proforma guid.
        /// </summary>
        public Guid? CswProformaGuid { get; set; }

        /// <summary>
        /// Gets or sets Currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets Date canceled.
        /// </summary>
        public DateTime DateCanceled { get; set; }

        /// <summary>
        /// Gets or sets Date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets Date from.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets Date to.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets Duration type.
        /// </summary>
        public DurationType? DurationType { get; set; }

        /// <summary>
        /// Gets or sets The entity's Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether subscription is canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether subscription is Trial.
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets Order type.
        /// </summary>
        public OrderType? OrderType { get; set; }

        /// <summary>
        /// Gets or sets Payment merhod.
        /// </summary>
        public PaymentMethodType? PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets Total price without VAT.
        /// </summary>
        public decimal PriceWithoutVat { get; set; }

        /// <summary>
        /// Gets or sets Total price with VAT.
        /// </summary>
        public decimal PriceWithVat { get; set; }

        /// <summary>
        /// Gets or sets Subscription type.
        /// </summary>
        public SubscriptionType SubscriptionType { get; set; }

        /// <summary>
        /// Gets or sets Variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }
    }
}
