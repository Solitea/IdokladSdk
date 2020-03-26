using System;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.PaymentOption.Filter
{
    /// <summary>
    /// Filterable properties of payment option.
    /// </summary>
    public class PaymentOptionFilter
    {
        /// <inheritdoc cref="PaymentOptionListGetModel.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(PaymentOptionListGetModel.DateLastChange));
    }
}
