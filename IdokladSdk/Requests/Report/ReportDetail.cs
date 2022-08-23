using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report
{
    /// <summary>
    /// ReportDetail.
    /// </summary>
    public class ReportDetail : ReportBaseDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDetail"/> class.
        /// </summary>
        /// <param name="invoiceId">Id.</param>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        public ReportDetail(int invoiceId, ReportClient client, ReportDocumentType documentType)
            : base(invoiceId, client, documentType)
        {
        }

        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<string> Get(ReportOption option = null)
        {
            return GetAsync(option).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get image report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<List<ReportImageGetModel>> GetImage(ReportImageOption option = null)
        {
            return GetImageAsync(option).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get report async.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<string>> GetAsync(ReportOption option = null, CancellationToken cancellationToken = default)
        {
            if (option == null)
            {
                return GetBaseAsync(null, cancellationToken);
            }

            return GetBaseAsync(new ExtendedReportOption { Language = option.Language, Compressed = option.Compressed }, cancellationToken);
        }

        /// <summary>
        /// Get image report async.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<List<ReportImageGetModel>>> GetImageAsync(ReportImageOption option = null, CancellationToken cancellationToken = default)
        {
            if (option == null)
            {
                return GetImageBaseAsync(null, cancellationToken);
            }

            return GetImageBaseAsync(new ExtendedReportImageOption { Language = option.Language }, cancellationToken);
        }
    }
}
