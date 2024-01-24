using System;
using IdokladSdk.Models.ReadOnly.ExchangeRate;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.ExchangeRate.Filter
{
    /// <summary>
    /// Filterable properties of exchange rate.
    /// </summary>
    public class ExchangeRateFilter : IdFilter
    {
        /// <inheritdoc cref="ExchangeRateListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(ExchangeRateListGetModel.CurrencyId));

        /// <inheritdoc cref="ExchangeRateListGetModel.Date"/>
        public CompareFilterItem<DateTime> Date { get; set; } = new CompareFilterItem<DateTime>(nameof(ExchangeRateListGetModel.Date));

        /// <inheritdoc cref="ExchangeRateListGetModel.ExchangeListId"/>
        public FilterItem<int> ExchangeListId { get; set; } = new FilterItem<int>(nameof(ExchangeRateListGetModel.ExchangeListId));
    }
}
