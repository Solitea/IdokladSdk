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
        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public FilterItem<string> PartnerName { get; set; } = new CompareFilterItem<string>(nameof(PaymentsForIssuedTaxDocumentGetModel.PartnerName));

        /// <inheritdoc cref="PaymentsForIssuedTaxDocumentGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(PaymentsForIssuedTaxDocumentGetModel.DateOfPayment));
    }
}
