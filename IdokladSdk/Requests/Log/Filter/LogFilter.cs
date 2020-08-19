using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Log;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Log.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="LogGetModel" />.
    /// </summary>
    public class LogFilter
    {
        /// <inheritdoc cref="LogGetModel.ActionType" />
        public FilterItem<LogActionType> ActionType { get; set; } =
            new FilterItem<LogActionType>(nameof(LogGetModel.ActionType));

        /// <inheritdoc cref="Metadata.DateLastChange" />
        public CompareFilterItem<DateTime> DateFrom { get; set; } =
            new CompareFilterItem<DateTime>(nameof(LogFilter.DateFrom));

        /// <inheritdoc cref="Metadata.DateLastChange" />
        public CompareFilterItem<DateTime> DateTo { get; set; } =
            new CompareFilterItem<DateTime>(nameof(LogFilter.DateTo));

        /// <inheritdoc cref="LogGetModel.EntityType" />
        public FilterItem<LogEntityType> EntityType { get; set; } =
            new FilterItem<LogEntityType>(nameof(LogGetModel.EntityType));
    }
}
