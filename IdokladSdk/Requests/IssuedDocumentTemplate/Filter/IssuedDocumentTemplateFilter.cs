using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.IssuedDocumentTemplate.List;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedDocumentTemplate.Filter
{
    /// <summary>
    /// IssuedDocumentTemplateFilter.
    /// </summary>
    public class IssuedDocumentTemplateFilter : IdFilter
    {
        /// <inheritdoc cref="IssuedDocumentTemplateListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(IssuedDocumentTemplateListGetModel.CurrencyId));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(IssuedDocumentTemplateListGetModel.Partner.Id));

        /// <inheritdoc cref="IssuedDocumentTemplateListGetModel.Name"/>
        public ContainFilterItem<string> Name { get; set; } = new ContainFilterItem<string>(nameof(IssuedDocumentTemplateListGetModel.Name));

        /// <inheritdoc cref="IssuedDocumentTemplateListGetModel.DocumentType"/>
        public FilterItem<IssuedDocumentTemplateType> DocumentType { get; set; } = new FilterItem<IssuedDocumentTemplateType>(nameof(IssuedDocumentTemplateListGetModel.DocumentType));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="ContactListGetModel.CompanyName"/>
        public ContainFilterItem<string> CompanyName { get; set; } = new ContainFilterItem<string>(nameof(IssuedDocumentTemplateListGetModel.Partner.CompanyName));
    }
}
