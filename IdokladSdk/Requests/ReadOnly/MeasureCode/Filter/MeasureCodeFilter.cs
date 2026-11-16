using System;
using IdokladSdk.Models.ReadOnly.MeasureCode;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.MeasureCode.Filter
{
    /// <summary>
    /// Supported filters for units of measure.
    /// </summary>
    public class MeasureCodeFilter : IdFilter
    {
        /// <inheritdoc cref="MeasureCodeListGetModel.Code"/>
        public ContainFilterItem<string> Code { get; set; } = new ContainFilterItem<string>(nameof(MeasureCodeListGetModel.Code));

        /// <inheritdoc cref="MeasureCodeListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(MeasureCodeListGetModel.DateLastChange));
    }
}
