using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.ReadOnly.VatRate;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.VatRate.Filter
{
    /// <summary>
    /// Filterable properties of VAT rate.
    /// </summary>
    public class VatRateFilter
    {
        /// <inheritdoc cref="VatRateListGetModel.CountryId"/>
        public FilterItem<int> CountryId { get; set; } = new FilterItem<int>(nameof(VatRateListGetModel.CountryId));

        /// <inheritdoc cref="VatRateListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(VatRateListGetModel.DateLastChange));

        /// <inheritdoc cref="VatRateListGetModel.DateValidityFrom"/>
        public CompareFilterItem<DateTime> DateValidityFrom { get; set; } = new CompareFilterItem<DateTime>(nameof(VatRateListGetModel.DateValidityFrom));

        /// <inheritdoc cref="VatRateListGetModel.DateValidityTo"/>
        public CompareFilterItem<DateTime> DateValidityTo { get; set; } = new CompareFilterItem<DateTime>(nameof(VatRateListGetModel.DateValidityTo));

        /// <inheritdoc cref="VatRateListGetModel.RateType"/>
        public CompareFilterItem<VatRateType> RateType { get; set; } = new CompareFilterItem<VatRateType>("Type");
    }
}
