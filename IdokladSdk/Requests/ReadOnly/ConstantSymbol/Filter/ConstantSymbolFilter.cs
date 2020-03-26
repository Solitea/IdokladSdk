using System;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.ConstantSymbol.Filter
{
    /// <summary>
    /// Filterable properties of constant symbol.
    /// </summary>
    public class ConstantSymbolFilter
    {
        /// <inheritdoc cref="ConstantSymbolListGetModel.CountryId"/>
        public FilterItem<int> CountryId { get; set; } = new FilterItem<int>(nameof(ConstantSymbolListGetModel.CountryId));

        /// <inheritdoc cref="ConstantSymbolListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(ConstantSymbolListGetModel.DateLastChange));
    }
}
