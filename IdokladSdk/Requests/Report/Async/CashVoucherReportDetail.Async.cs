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
    }
}
