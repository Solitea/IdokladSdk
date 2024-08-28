using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.UnpairedDocument.List
{
    /// <summary>
    /// UnpairedDocumentListGetModel.
    /// </summary>
    public class UnpairedDocumentListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        public DateTime DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public PairedDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets payment status.
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets total amount remaining to pay.
        /// </summary>
        public decimal TotalAmountRemainingToPay { get; set; }

        /// <summary>
        /// Gets or sets total paid.
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// Gets or sets total with vat.
        /// </summary>
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }
    }
}
