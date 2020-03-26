using System;
using IdokladSdk.Models.ReadOnly.VatCode;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReadOnly.VatCodes.Filter
{
    /// <summary>
    /// Filterable properties of VAT code.
    /// </summary>
    public class VatCodeFilter
    {
        /// <inheritdoc cref="VatCodeListGetModel.CountryId"/>
        public FilterItem<int> CountryId { get; set; } = new FilterItem<int>(nameof(VatCodeListGetModel.CountryId));

        /// <inheritdoc cref="VatCodeListGetModel.DateValidityFrom"/>
        public CompareFilterItem<DateTime> DateValidityFrom { get; set; } = new CompareFilterItem<DateTime>(nameof(VatCodeListGetModel.DateValidityFrom));

        /// <inheritdoc cref="VatCodeListGetModel.DateValidityTo"/>
        public CompareFilterItem<DateTime> DateValidityTo { get; set; } = new CompareFilterItem<DateTime>(nameof(VatCodeListGetModel.DateValidityTo));

        /// <inheritdoc cref="VatCodeListGetModel.Code"/>
        public ContainFilterItem<string> Code { get; set; } = new ContainFilterItem<string>(nameof(VatCodeListGetModel.Code));

        /// <inheritdoc cref="VatCodeListGetModel.Name"/>
        public ContainFilterItem<string> Name { get; set; } = new ContainFilterItem<string>(nameof(VatCodeListGetModel.Name));

        /// <inheritdoc cref="VatCodeListGetModel.MoneyS3Code"/>
        public ContainFilterItem<string> MoneyS3Code { get; set; } = new ContainFilterItem<string>(nameof(VatCodeListGetModel.MoneyS3Code));

        /// <inheritdoc cref="VatCodeListGetModel.MoneyS5Code"/>
        public ContainFilterItem<string> MoneyS5Code { get; set; } = new ContainFilterItem<string>(nameof(VatCodeListGetModel.MoneyS5Code));
    }
}
