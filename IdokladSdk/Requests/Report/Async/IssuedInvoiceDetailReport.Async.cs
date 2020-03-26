using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report.IssuedInvoice
{
    public partial class IssuedInvoiceDetailReport
    {
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
    }
}
