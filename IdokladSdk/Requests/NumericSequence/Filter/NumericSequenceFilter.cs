using IdokladSdk.Enums;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.NumericSequence.Filter
{
    /// <summary>
    /// NumericSequenceFilter.
    /// </summary>
    public class NumericSequenceFilter
    {
        /// <inheritdoc cref="NumericSequenceGetModel.DocumentType"/>
        public FilterItem<NumericSequenceDocumentType> DocumentType { get; set; } = new FilterItem<NumericSequenceDocumentType>(nameof(NumericSequenceGetModel.DocumentType));

        /// <inheritdoc cref="NumericSequenceGetModel.Id"/>
        public CompareFilterItem<int> Id { get; set; } = new CompareFilterItem<int>(nameof(NumericSequenceGetModel.Id));

        /// <inheritdoc cref="NumericSequenceGetModel.IsDefault"/>
        public FilterItem<bool> IsDefault { get; set; } = new FilterItem<bool>(nameof(NumericSequenceGetModel.IsDefault));
    }
}
