using System;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.VatReverseChargeCodes.Filter
{
    /// <summary>
    /// Filterable properties of VAT reverse charge code.
    /// </summary>
    public class VatReverseChargeCodeFilter
    {
        /// <inheritdoc cref="VatReverseChargeCodeListGetModel.Code"/>
        public ContainFilterItem<int> Code { get; set; } = new ContainFilterItem<int>(nameof(VatReverseChargeCodeListGetModel.Code));

        /// <inheritdoc cref="VatReverseChargeCodeListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(VatReverseChargeCodeListGetModel.DateLastChange));

        /// <inheritdoc cref="VatReverseChargeCodeListGetModel.DateValidityFrom"/>
        public CompareFilterItem<DateTime> DateValidityFrom { get; set; } = new CompareFilterItem<DateTime>(nameof(VatReverseChargeCodeListGetModel.DateValidityFrom));

        /// <inheritdoc cref="VatReverseChargeCodeListGetModel.DateValidityTo"/>
        public CompareFilterItem<DateTime> DateValidityTo { get; set; } = new CompareFilterItem<DateTime>(nameof(VatReverseChargeCodeListGetModel.DateValidityTo));
    }
}
