using System;
using IdokladSdk.Enums;
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

        /// <inheritdoc cref="BankStatementListGetModel.Status"/>
        public CompareFilterItem<BankStatementPairingStatus> Status { get; set; } = new CompareFilterItem<BankStatementPairingStatus>(nameof(BankStatementListGetModel.Status));

        /// <inheritdoc cref="BankStatementListGetModel.MovementType"/>
        public CompareFilterItem<MovementType> MovementType { get; set; } = new CompareFilterItem<MovementType>(nameof(BankStatementListGetModel.MovementType));

        /// <inheritdoc cref="BankStatementListGetModel.DateOfTransaction"/>
        public CompareFilterItem<DateTime> DateOfTransaction { get; set; } = new CompareFilterItem<DateTime>(nameof(BankStatementListGetModel.DateOfTransaction));

        /// <inheritdoc cref="BankStatementListGetModel.PartnerName"/>
        public CompareFilterItem<string> PartnerName { get; set; } = new CompareFilterItem<string>(nameof(BankStatementListGetModel.PartnerName));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainTagIdFilterItem TagIds { get; set; } = new ContainTagIdFilterItem("TagIds");
    }
}
