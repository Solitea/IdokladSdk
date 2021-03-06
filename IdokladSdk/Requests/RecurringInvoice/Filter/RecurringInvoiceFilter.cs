﻿using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.RecurringInvoice.Filter
{
    /// <summary>
    /// Filterable properties for <see cref="RecurringInvoiceListGetModel"/>.
    /// </summary>
    public class RecurringInvoiceFilter : IdFilter
    {
        /// <inheritdoc cref="InvoiceTemplateListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(InvoiceTemplateListGetModel.CurrencyId));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="RecurringSettingListGetModel.DateOfLastIssue"/>
        public CompareFilterItem<DateTime> DateLastOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(RecurringSettingListGetModel.DateOfLastIssue));

        /// <inheritdoc cref="InvoiceTemplateListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } = new ContainFilterItem<string>(nameof(InvoiceTemplateListGetModel.Description));

        /// <inheritdoc cref="InvoiceTemplateListGetModel.DocumentType"/>
        public FilterItem<RecurringDocumentType> DocumentType { get; set; } = new FilterItem<RecurringDocumentType>(nameof(InvoiceTemplateListGetModel.DocumentType));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(InvoiceTemplateListGetModel.Partner.Id));

        /// <inheritdoc cref="RecurringSettingListGetModel.RecurrenceCount"/>
        public CompareFilterItem<int> RecurrenceCount { get; set; } = new CompareFilterItem<int>(nameof(RecurringSettingListGetModel.RecurrenceCount));

        /// <inheritdoc cref="RecurringSettingListGetModel.RecurrenceType"/>
        public FilterItem<RecurrenceType> RecurrenceType { get; set; } = new FilterItem<RecurrenceType>(nameof(RecurringSettingListGetModel.RecurrenceType));

        /// <inheritdoc cref="RecurringSettingListGetModel.TemplateName"/>
        public ContainFilterItem<string> TemplateName { get; set; } = new ContainFilterItem<string>(nameof(RecurringSettingListGetModel.TemplateName));

        /// <inheritdoc cref="ContactListGetModel.CompanyName"/>
        public ContainFilterItem<string> CompanyName { get; set; } = new ContainFilterItem<string>(nameof(InvoiceTemplateGetModel.Partner.CompanyName));
    }
}
