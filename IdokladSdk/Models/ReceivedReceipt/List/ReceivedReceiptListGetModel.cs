﻿using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Attachment;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;

namespace IdokladSdk.Models.ReceivedReceipt.List
{
    /// <summary>
    /// ReceivedReceiptListGetModel.
    /// </summary>
    public class ReceivedReceiptListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets the accountant sent status.
        /// </summary>
        public MailSentType AccountantSentStatus { get; set; }

        /// <summary>
        /// Gets or sets the list of attachments.
        /// </summary>
        public List<DocumentAttachmentInfo> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the paired bank statement ID.
        /// </summary>
        public int? BankStatementId { get; set; }

        /// <summary>
        /// Gets or sets the paired cash voucher ID.
        /// </summary>
        public int? CashVoucherId { get; set; }

        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date of issue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets the document description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the document serial number.
        /// </summary>
        public int? DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets the export status to another accounting software.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <summary>
        /// Gets or sets the external document number.
        /// </summary>
        public string ExternalDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the entity's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is included in the income tax report.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets the list of invoice items.
        /// </summary>
        public List<ReceivedReceiptItemListGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets the payment option ID.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the prices and calculations.
        /// </summary>
        public Prices Prices { get; set; }

        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets the receipt's status.
        /// </summary>
        public ReceivedReceiptDependencyStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the list of tags.
        /// </summary>
        public List<TagDocumentGetModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets the VAT regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
