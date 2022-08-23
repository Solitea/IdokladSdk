using System;
using System.Collections.Generic;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceDetailReport.
    /// </summary>
    public partial class IssuedInvoiceDetailReport : ReportBaseDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceDetailReport"/> class.
        /// </summary>
        /// <param name="invoiceId">Id.</param>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        public IssuedInvoiceDetailReport(int invoiceId, ReportClient client, ReportDocumentType documentType)
            : base(invoiceId, client, documentType)
        {
        }

        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<string> Get(ExtendedReportOption option = null)
        {
            return GetAsync(option).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get image report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<List<ReportImageGetModel>> GetImage(ExtendedReportImageOption option = null)
        {
            return GetImageAsync(option).GetAwaiter().GetResult();
        }
    }
}
