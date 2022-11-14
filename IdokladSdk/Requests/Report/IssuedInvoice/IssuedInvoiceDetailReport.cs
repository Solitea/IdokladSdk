using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceDetailReport.
    /// </summary>
    public class IssuedInvoiceDetailReport : ReportBaseDetail
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<string>> GetAsync(ExtendedReportOption option = null, CancellationToken cancellationToken = default)
        {
            return GetBaseAsync(option, cancellationToken);
        }

        /// <summary>
        /// Get image report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<List<ReportImageGetModel>>> GetImageAsync(ExtendedReportImageOption option = null, CancellationToken cancellationToken = default)
        {
            return GetImageBaseAsync(option, cancellationToken);
        }
    }
}
