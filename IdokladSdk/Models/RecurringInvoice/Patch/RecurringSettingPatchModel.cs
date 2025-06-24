using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// RecurringSettingPatchModel.
    /// </summary>
    public class RecurringSettingPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets count of documents created before recurrence end. Applies to <see cref="RecurrenceTypeOfEnd.AfterNumberCreated"/>.
        /// </summary>
        [CopyCountEndOnRecurringInvoice(nameof(TypeOfEnd))]
        public NullableProperty<int> CopyCountEnd { get; set; }

        /// <summary>
        /// Gets or sets date of recurrence issue end. Applies to <see cref="RecurrenceTypeOfEnd.OnSpecificDate"/>.
        /// </summary>
        [DateOfEndOnRecurringInvoice(nameof(TypeOfEnd))]
        [DateGreaterOrEqualThanToday]
        public NullableProperty<DateTime> DateOfEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document will be issued last day of month. Applies to <see cref="Enums.RecurrenceType.Months"/>.
        /// </summary>
        [IssueLastDayOfMonthOnRecurringInvoice(nameof(RecurrenceType), nameof(RecurrenceCount))]
        public bool IssueLastDayOfMonth { get; set; }

        /// <summary>
        /// Gets or sets interval between issues RecurrenceType.
        /// </summary>
        [Range(1, 999)]
        [Required]
        public int RecurrenceCount { get; set; }

        /// <summary>
        /// Gets or sets recurrence period type.
        /// </summary>
        [Required]
        public RecurrenceType RecurrenceType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to accountant.
        /// </summary>
        public bool? SendToAccountant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to other receiver in the contact.
        /// </summary>
        public bool? SendToOtherEmails { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to purchaser.
        /// </summary>
        public bool? SendToPurchaser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether issued document is sent to supplier.
        /// </summary>
        public bool? SendToSupplier { get; set; }

        /// <summary>
        /// Gets or sets name of recurring invoice.
        /// </summary>
        [NotEmptyString]
        [StringLength(200)]
        public string TemplateName { get; set; }

        /// <summary>
        /// Gets or sets yype of end.
        /// </summary>
        [Required]
        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
