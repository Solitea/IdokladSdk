using System;
using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementListGetModel.
    /// </summary>
    public class BankStatementListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets your bank account id.
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets current account balance.
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Gets or sets documentNumber.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets bank statement items.
        /// </summary>
        public List<BankStatementItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity..
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets start date of the statement.
        /// </summary>
        public DateTime PeriodDateFrom { get; set; }

        /// <summary>
        /// Gets or sets end date of the statement.
        /// </summary>
        public DateTime PeriodDateTo { get; set; }
    }
}
