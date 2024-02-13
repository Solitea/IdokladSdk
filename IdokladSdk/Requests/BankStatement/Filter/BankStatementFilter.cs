using System;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.BankStatement.Filter
{
    /// <summary>
    /// BankStatementFilter.
    /// </summary>
    public class BankStatementFilter : IdFilter
    {
        /// <inheritdoc cref="BankStatementListGetModel.BankAccountId"/>
        public FilterItem<int> BankAccountId { get; set; } = new FilterItem<int>(nameof(BankStatementListGetModel.BankAccountId));

        /// <inheritdoc cref="BankStatementListGetModel.DocumentNumber"/>
        public CompareFilterItem<string> DocumentNumber { get; set; } = new CompareFilterItem<string>(nameof(BankStatementListGetModel.DocumentNumber));

        /// <inheritdoc cref="BankStatementListGetModel.NumericSequenceId"/>
        public FilterItem<int> NumericSequenceId { get; set; } = new FilterItem<int>(nameof(BankStatementListGetModel.NumericSequenceId));

        /// <inheritdoc cref="BankStatementListGetModel.PeriodDateFrom"/>
        public CompareFilterItem<DateTime> PeriodDateFrom { get; set; } = new CompareFilterItem<DateTime>(nameof(BankStatementListGetModel.PeriodDateFrom));

        /// <inheritdoc cref="BankStatementListGetModel.PeriodDateTo"/>
        public CompareFilterItem<DateTime> PeriodDateTo { get; set; } = new CompareFilterItem<DateTime>(nameof(BankStatementListGetModel.PeriodDateTo));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainTagIdFilterItem TagIds { get; set; } = new ContainTagIdFilterItem("TagIds");
    }
}
