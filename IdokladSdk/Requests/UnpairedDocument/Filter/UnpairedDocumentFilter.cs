using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.UnpairedDocument.List;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.UnpairedDocument.Filter
{
    /// <inheritdoc cref="UnpairedDocumentListGetModel"/>>
    public class UnpairedDocumentFilter : IdFilter
    {
        /// <inheritdoc cref="UnpairedDocumentListGetModel.VariableSymbol"/>
        public ContainFilterItem<string> VariableSymbol { get; set; } = new ContainFilterItem<string>(nameof(UnpairedDocumentListGetModel.VariableSymbol));

        /// <inheritdoc cref="UnpairedDocumentListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(UnpairedDocumentListGetModel.PartnerId));

        /// <inheritdoc cref="UnpairedDocumentListGetModel.PartnerName"/>
        public ContainFilterItem<string> PartnerName { get; set; } = new ContainFilterItem<string>(nameof(UnpairedDocumentListGetModel.PartnerName));

        /// <inheritdoc cref="UnpairedDocumentListGetModel.DocumentType"/>
        public FilterItem<PairedDocumentType> DocumentType { get; set; } = new FilterItem<PairedDocumentType>(nameof(UnpairedDocumentListGetModel.DocumentType));

        /// <inheritdoc cref="UnpairedDocumentListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(UnpairedDocumentListGetModel.DateOfIssue));

        /// <inheritdoc cref="UnpairedDocumentListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(UnpairedDocumentListGetModel.CurrencyId));
    }
}
