using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report.CashVoucher
{
    public partial class CashVoucherReportDetail
    {
        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<string>> GetAsync(ReportOption option = null, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            if (option == null)
            {
                return GetBaseAsync(resource, null, cancellationToken);
            }

            return GetBaseAsync(resource, new ExtendedReportOption { Language = option.Language, Compressed = option.Compressed }, cancellationToken);
        }

        /// <summary>
        /// Get image report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<List<ReportImageGetModel>>> GetImageAsync(ReportImageOption option = null, CancellationToken cancellationToken = default)
        {
            var resource = GetImageResource();
            if (option == null)
            {
                return GetImageBaseAsync(resource, null, cancellationToken);
            }

            return GetImageBaseAsync(resource, new ExtendedReportImageOption { Language = option.Language }, cancellationToken);
        }
    }
}
