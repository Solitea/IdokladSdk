using System;
using IdokladSdk.Enums;
using IdokladSdk.Serialization;
using Newtonsoft.Json;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringSettingListGetModel.
    /// </summary>
    public class RecurringSettingListGetModel
    {
        /// <summary>
        /// Gets or sets current count of issued documents from recurring invoice. Applies to <see cref="RecurrenceTypeOfEnd.AfterNumberCreated"/>.
        /// </summary>
        public int? CopyCountActual { get; set; }

        /// <summary>
        /// Gets or sets count of documents created before recurrence end. Applies to <see cref="RecurrenceTypeOfEnd.AfterNumberCreated"/>.
        /// </summary>
        public int? CopyCountEnd { get; set; }

        /// <summary>
        /// Gets or sets date of recurrence issue end. Applies to <see cref="RecurrenceTypeOfEnd.OnSpecificDate"/>.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DateOfEnd { get; set; }

        /// <summary>
        /// Gets or sets date of last issued document.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DateOfLastIssue { get; set; }

        /// <summary>
        /// Gets or sets date of next issue.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DateOfNextIssue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets date of last activation of recurring invoice. Same as DateOfLastIssue with exception for reactivating after new subscription bought.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DateOfLastActivation { get; set; }

        /// <summary>
        /// Gets or sets date of first issue.
        /// </summary>
        public DateTime DateOfStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document will be issued last day of month. Applies to <see cref="Enums.RecurrenceType.Months"/>.
        /// </summary>
        public bool IssueLastDayOfMonth { get; set; }

        /// <summary>
        /// Gets or sets interval between issues RecurrenceType.
        /// </summary>
        public int RecurrenceCount { get; set; }

        /// <summary>
        /// Gets or sets recurrence period type.
        /// </summary>
        public RecurrenceType RecurrenceType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to purchaser.
        /// </summary>
        public bool SendToPurchaser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to supplier.
        /// </summary>
        public bool SendToSupplier { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to accountant.
        /// </summary>
        public bool SendToAccountant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to other receiver in the contact.
        /// </summary>
        public bool SendToOtherEmails { get; set; }

        /// <summary>
        /// Gets or sets name of recurring invoice.
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Gets or sets type of end.
        /// </summary>
        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
