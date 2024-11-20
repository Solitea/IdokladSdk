using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Payment.DocumentPayments.Purchases.SubModels
{
    /// <summary>
    /// PaidPurchaseDocument.
    /// </summary>
    public class PaidPurchaseDocument
    {
        /// <summary>
        /// Gets or sets the date of maturity.
        /// </summary>
        public DateTime DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets the description of the document.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the document type.
        /// </summary>
        public PurchasePaymentForDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the exported state, indicating export to another accounting software.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <summary>
        /// Gets or sets the document ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is included in the income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets the partner contact ID.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the partner name.
        /// </summary>
        public string PartnerName { get; set; }
    }
}
