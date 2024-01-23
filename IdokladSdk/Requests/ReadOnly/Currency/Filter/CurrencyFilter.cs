using System;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.Currency.Filter
{
    /// <summary>
    /// Filterable properties of currency.
    /// </summary>
    public class CurrencyFilter : IdFilter
    {
        /// <inheritdoc cref="CurrencyListGetModel.Code"/>
        public ContainFilterItem<string> Code { get; set; } = new ContainFilterItem<string>(nameof(CurrencyListGetModel.Code));

        /// <inheritdoc cref="ConstantSymbolListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(ConstantSymbolListGetModel.DateLastChange));
    }
}
