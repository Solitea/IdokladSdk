using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.EDocument
{
    /// <summary>
    /// Settings for sending an electronic invoice. Available only for Slovak legislation.
    /// </summary>
    public class EInvoiceSendModel : ValidatableModel
    {
        /// <summary>Gets or sets the attachment IDs to include.</summary>
        public int[] AttachmentIds { get; set; } = Array.Empty<int>();

        /// <summary>Gets or sets the delivery mode.</summary>
        [Range(0, 1)]
        public EInvoiceDeliveryMode DeliveryMode { get; set; }

        /// <summary>Gets or sets the document ID.</summary>
        [RequiredNonDefault]
        public int DocumentId { get; set; }

        /// <summary>Gets or sets the email body. When omitted, the agenda setting is used.</summary>
        public string EmailBody { get; set; }

        /// <summary>Gets or sets the email subject. When omitted, the agenda setting is used.</summary>
        public string EmailSubject { get; set; }

        /// <summary>Gets or sets the email send method. When omitted, the agenda setting is used.</summary>
        [Range(0, 1)]
        public EInvoiceSendMethod? Method { get; set; }

        /// <summary>Gets or sets the other recipients.</summary>
        [CollectionRange(0, 5)]
        [EmailCollection]
        public List<string> OtherRecipients { get; set; } = new List<string>();

        /// <summary>Gets or sets a value indicating whether to send to the accountant.</summary>
        public bool SendToAccountant { get; set; }

        /// <summary>Gets or sets a value indicating whether to send to the document partner.</summary>
        public bool SendToPartner { get; set; }

        /// <summary>Gets or sets a value indicating whether to send a copy to the company email.</summary>
        public bool SendToSelf { get; set; }

        /// <summary>Gets or sets a value indicating whether to include document attachments. When omitted, the agenda setting is used.</summary>
        public bool? SendAttachments { get; set; }

        /// <summary>Gets or sets a value indicating whether to include the document PDF. When omitted, the agenda setting is used.</summary>
        public bool? SendDocumentPdf { get; set; }
    }
}
