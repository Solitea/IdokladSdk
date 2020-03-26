using System;
using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.Bank.Filter
{
    /// <summary>
    /// Filterable properties of bank.
    /// </summary>
    public class BankFilter
    {
        /// <inheritdoc cref="BankListGetModel.CountryId"/>
        public FilterItem<int> CountryId { get; set; } = new FilterItem<int>(nameof(BankListGetModel.CountryId));

        /// <inheritdoc cref="BankListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(BankListGetModel.DateLastChange));

        /// <inheritdoc cref="BankListGetModel.IsOutOfDate"/>
        public FilterItem<bool> IsOutOfDate { get; set; } = new FilterItem<bool>(nameof(BankListGetModel.IsOutOfDate));
    }
}
