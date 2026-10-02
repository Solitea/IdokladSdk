using System;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaAiCreditsGetModel.
    /// </summary>
    public class AgendaAiCreditsGetModel
    {
        /// <summary>
        /// Gets or sets actual number of credits.
        /// </summary>
        public int AiCreditCount { get; set; }

        /// <summary>
        /// Gets or sets actual number of credits agenda obtained when inbox was enabled.
        /// </summary>
        public int StartAiCreditCount { get; set; }

        /// <summary>
        /// Gets or sets number of credits to be expired within next month.
        /// </summary>
        public int ExpiringAiCreditCount { get; set; }

        /// <summary>
        /// Gets or sets expiration date of credits.
        /// </summary>
        public DateTime DateExpiringAiCredit { get; set; }
    }
}
