using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// SendReminderSettingsPatchModel.
    /// </summary>
    public class SendReminderSettingsPatchModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether to send reminders automatically.
        /// </summary>
        public bool? IsSendReminder { get; set; }

        /// <summary>
        /// Gets or sets the number of days after which another reminder should be sent.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int? NextReminderIntervalInDays { get; set; }

        /// <summary>
        /// Gets or sets the number of days after the invoice maturity to send a reminder.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int? ReminderDaysAfterMaturity { get; set; }

        /// <summary>
        /// Gets or sets the amount of the invoice from which to send reminders.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        public decimal? ReminderMinValue { get; set; }
    }
}
