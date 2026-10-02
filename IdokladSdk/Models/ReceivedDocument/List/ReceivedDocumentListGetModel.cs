using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.ReceivedDocument.List
{
    /// <summary>
    /// Received document list GET model.
    /// </summary>
    public class ReceivedDocumentListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets date of receiving.
        /// </summary>
        public DateTime DateOfReceiving { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public InboxAttachmentDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets total amount with VAT.
        /// </summary>
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }
    }
}
