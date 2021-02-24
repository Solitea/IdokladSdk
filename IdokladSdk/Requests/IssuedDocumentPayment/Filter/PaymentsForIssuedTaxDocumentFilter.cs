using System;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedDocumentPayment.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="PaymentsForIssuedTaxDocumentGetModel"/>.
    /// </summary>
    public class PaymentsForIssuedTaxDocumentFilter : IdFilter
    {
        /// <inheritdoc cref="PaymentsForIssuedTaxDocumentGetModel.PartnerName"/>
        public ContainFilterItem<string> PartnerName { get; set; } = new ContainFilterItem<string>(nameof(PaymentsForIssuedTaxDocumentGetModel.PartnerName));

        /// <inheritdoc cref="PaymentsForIssuedTaxDocumentGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(PaymentsForIssuedTaxDocumentGetModel.DateOfPayment));
    }
}
