using IdokladSdk.Enums;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.NumericSequence.Filter
{
    /// <summary>
    /// NumericSequenceFilter.
    /// </summary>
    public class NumericSequenceFilter : IdFilter
    {
        /// <inheritdoc cref="NumericSequenceGetModel.DocumentType"/>
        public FilterItem<NumericSequenceDocumentType> DocumentType { get; set; } = new FilterItem<NumericSequenceDocumentType>(nameof(NumericSequenceGetModel.DocumentType));

        /// <inheritdoc cref="NumericSequenceGetModel.IsDefault"/>
        public FilterItem<bool> IsDefault { get; set; } = new FilterItem<bool>(nameof(NumericSequenceGetModel.IsDefault));
    }
}
