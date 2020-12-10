using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// NextIssueDatesPostModel.
    /// </summary>
    public class NextIssueDatesPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets current count of issued documents from recurring invoice. Applies to <see cref="RecurrenceTypeOfEnd.AfterNumberCreated"/>.
        /// </summary>
        public int? CopyCountActual { get; set; }

        /// <summary>
        /// Gets or sets count of documents after which the recurrence will end. Applies to <see cref="RecurrenceTypeOfEnd.AfterNumberCreated"/>.
        /// </summary>
        public int? CopyCountEnd { get; set; }

        /// <summary>
        /// Gets or sets date of recurrence issue end. Applies to <see cref="RecurrenceTypeOfEnd.OnSpecificDate"/>.
        /// </summary>
        public DateTime? DateOfEnd { get; set; }

        /// <summary>
        /// Gets or sets date of last activation of recurring invoice. Differs from DateOfLastIssue in case of interrupted issue due subscription restriction.
        /// </summary>
        [Required]
        public DateTime DateOfLastActivation { get; set; }

        /// <summary>
        /// Gets or sets date of last created document. <see cref="RecurrenceTypeOfEnd.OnSpecificDate"/>.
        /// </summary>
        [Required]
        public DateTime DateOfLastIssue { get; set; }

        /// <summary>
        /// Gets or sets Date of first issue.
        /// </summary>
        [Required]
        public DateTime DateOfStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether document will be issued last day of month. Applies to <see cref="Enums.RecurrenceType.Months"/>.
        /// </summary>
        public bool IssueLastDayOfMonth { get; set; }

        /// <summary>
        /// Gets or sets interval between issues <see cref="RecurrenceType"/>.
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
        /// Gets or sets type of end.
        /// </summary>
        [Required]
        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
