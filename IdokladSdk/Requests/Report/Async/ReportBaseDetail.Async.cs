using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report
{
    public partial class ReportBaseDetail
    {
        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        protected Task<ApiResult<string>> GetBaseAsync(ExtendedReportOption option, CancellationToken cancellationToken)
        {
            var resource = GetResource(option);
            return GetBaseAsync(resource, option, cancellationToken);
        }

        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="resource">Resource.</param>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        protected Task<ApiResult<string>> GetBaseAsync(string resource, ExtendedReportOption option, CancellationToken cancellationToken)
        {
            var queryParams = CreateQueryParams(option);
            return Client.GetAsync<string>(resource, queryParams, cancellationToken);
        }
    }
}
