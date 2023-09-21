using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.SubModels
{
    /// <summary>
    /// PaidDocument.
    /// </summary>
    public class PaidDocument
    {
        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        public DateTime DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public ApiSalesPaymentForDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets exported.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets is income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets vat on pay status.
        /// </summary>
        public VatOnPayStatus VatOnPayStatus { get; set; }
    }
}
