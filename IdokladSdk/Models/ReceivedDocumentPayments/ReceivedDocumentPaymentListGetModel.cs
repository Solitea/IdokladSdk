using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.ReceivedDocumentPayments.SubModels;

namespace IdokladSdk.Models.ReceivedDocumentPayments
{
    /// <summary>
    /// List item of received invoice payment.
    /// </summary>
    public class ReceivedDocumentPaymentListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets datum uplatnění DPH.
        /// </summary>
        public DateTime DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets export to another accounting software indication.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string InvoiceDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document Id.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public string Partner { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets payment document.
        /// </summary>
        public ReceivedPaymentDocument PaymentDocument { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public PaymentPrices Prices { get; set; }
    }
}
