using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.RegisteredSale;

namespace IdokladSdk.Models.IssuedDocumentPayment
{
    /// <summary>
    /// IssuedDocumentPaymentListGetModel.
    /// </summary>
    public class IssuedDocumentPaymentListGetModel : IEntityId
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
        /// Gets or sets date of vat application.
        /// Only for Sk Legislation.
        /// </summary>
        public DateTime DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets Responsibility for handling of electronic records of sales of payments document.
        /// Only for Cz Legislation.
        /// </summary>
        public EetResponsibility EetResponsibility { get; set; }

        /// <summary>
        /// Gets or sets eetStatus.
        /// Only for Cz Legislation.
        /// </summary>
        public EetStatus EetStatus { get; set; }

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
        /// Gets or sets invoice Id.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the payment confirmation has been sent.
        /// </summary>
        public bool IsConfirmationSent { get; set; }

        /// <summary>
        /// Gets or sets a value Indicating whether the document of payment is registered in electronics records of sales.
        /// Only for Cz Legislation.
        /// </summary>
        public bool IsEet { get; set; }

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
        /// Gets or sets prices.
        /// </summary>
        public PaymentPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets registered sale.
        /// Only for Cz Legislation.
        /// </summary>
        public RegisteredSaleGetModel RegisteredSale { get; set; }
    }
}
