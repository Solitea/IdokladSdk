using System;
using IdokladSdk.Models.ReadOnly.Country;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.Country.Filter
{
    /// <summary>
    /// Filterable properties of country.
    /// </summary>
    public class CountryFilter : IdFilter
    {
        /// <inheritdoc cref="CountryListGetModel.Code"/>
        public ContainFilterItem<string> Code { get; set; } = new ContainFilterItem<string>(nameof(CountryListGetModel.Code));

        /// <inheritdoc cref="CountryListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(CountryListGetModel.CurrencyId));

        /// <inheritdoc cref="CountryListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(CountryListGetModel.DateLastChange));
    }
}
