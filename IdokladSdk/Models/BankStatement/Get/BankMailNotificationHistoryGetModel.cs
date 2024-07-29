using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankMailNotificationHistoryGetModel.
    /// </summary>
    public class BankMailNotificationHistoryGetModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets bank mail history id.
        /// </summary>
        public int BankMailHistoryId { get; set; }

        /// <summary>
        /// Gets or sets bank statement id.
        /// </summary>
        public int? BankStatementId { get; set; }

        /// <summary>
        /// Gets or sets date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets bank code.
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public BankMailHistoryStatus Status { get; set; }

        /// <summary>
        /// Gets or sets bank pairing status.
        /// </summary>
        public BankStatementPairingStatus? BankPairingStatus { get; set; }

        /// <summary>
        /// Gets or sets paid amount.
        /// </summary>
        public decimal? PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }
    }
}
