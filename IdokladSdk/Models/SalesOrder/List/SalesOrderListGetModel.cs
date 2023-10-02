using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Attachment;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DeliveryAddress;
using IdokladSdk.Models.DocumentAddress;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrder Model for Get list endpoints.
    /// </summary>
    public class SalesOrderListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets list of attachments. Currently, you can attach a maximum of one attachment.
        /// </summary>
        public List<DocumentAttachmentInfo> Attachments { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of expiration.
        /// </summary>
        public DateTime DateOfExpiration { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets delivery address.
        /// </summary>
        public DeliveryDocumentAddressGetModel DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document serial number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets exported.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets sales order items.
        /// </summary>
        public List<SalesOrderItemListGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets metadata.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets myAddress.
        /// </summary>
        public DocumentAddressModel MyAddress { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public DocumentAddressModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public Prices Prices { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        public SalesOrderState State { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<TagDocumentListGetModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
