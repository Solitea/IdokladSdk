using IdokladSdk.Models.BankAccount;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.BankAccount.Filter
{
    /// <summary>
    /// BankAccountFilter.
    /// </summary>
    public class BankAccountFilter : IdFilter
    {
        /// <inheritdoc cref="BankAccountListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(BankAccountListGetModel.CurrencyId));
    }
}
