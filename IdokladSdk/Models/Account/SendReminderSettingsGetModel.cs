namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// SendReminderSettingsGetModel.
    /// </summary>
    public class SendReminderSettingsGetModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether to send reminders automatically.
        /// </summary>
        public bool IsSendReminder { get; set; }

        /// <summary>
        /// Gets or sets the number of days after which another reminder should be sent.
        /// </summary>
        public int NextReminderIntervalInDays { get; set; }

        /// <summary>
        /// Gets or sets the number of days after the invoice maturity to send a reminder.
        /// </summary>
        public int ReminderDaysAfterMaturity { get; set; }

        /// <summary>
        /// Gets or sets the amount of the invoice from which to send reminders.
        /// </summary>
        public decimal ReminderMinValue { get; set; }
    }
}
