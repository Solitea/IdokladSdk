using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReceivedInvoice.Filter
{
    /// <inheritdoc cref="ReceivedInvoiceGetModel"/>
    public class ReceivedInvoiceFilter : IdFilter
    {
        /// <inheritdoc cref="ReceivedInvoiceListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(ReceivedInvoiceGetModel.CurrencyId));

        /// <summary>
        /// Gets or sets date last changed.
        /// </summary>
        public CompareFilterItem<DateTime> DateLastChanged { get; set; } = new CompareFilterItem<DateTime>("DateLastChanged");

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedInvoiceGetModel.DateOfIssue));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedInvoiceGetModel.DateOfPayment));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DateOfMaturity"/>
        public CompareFilterItem<DateTime> DateOfMaturity { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedInvoiceGetModel.DateOfMaturity));

        /// <inheritdoc cref="ReceivedInvoiceGetModel.DateOfTaxing"/>
        public CompareFilterItem<DateTime> DateOfTaxing { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedInvoiceGetModel.DateOfTaxing));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(ReceivedInvoiceGetModel.Exported));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } = new ContainFilterItem<string>(nameof(ReceivedInvoiceGetModel.Description));

        /// <inheritdoc cref="DocumentAddressModel.NickName"/>
        public ContainFilterItem<string> NickName { get; set; } = new ContainFilterItem<string>(nameof(DocumentAddressModel.NickName));

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        public FilterItem<int> NumericSequenceId { get; set; } = new FilterItem<int>("NumericSequenceId");

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(ReceivedInvoiceGetModel.DocumentNumber));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.PaymentStatus"/>
        public FilterItem<PaymentStatus> PaymentStatus { get; set; } = new FilterItem<PaymentStatus>(nameof(ReceivedInvoiceGetModel.PaymentStatus));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DateOfReceiving"/>
        public CompareFilterItem<DateTime> DateOfReceiving { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedInvoiceGetModel.DateOfReceiving));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.PartnerId"/>
        public FilterItem<int> SupplierId { get; set; } = new FilterItem<int>(nameof(SupplierId));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.VariableSymbol"/>
        public FilterItem<string> VariableSymbol { get; set; } = new FilterItem<string>(nameof(ReceivedInvoiceGetModel.VariableSymbol));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainIdFilterItem TagIds { get; set; } = new ContainIdFilterItem("TagIds");
    }
}
