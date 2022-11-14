using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using IdokladSdk.Enums;
using IdokladSdk.Models.Statistics;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with statistic endpoints.
    /// </summary>
    public class StatisticsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public StatisticsClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/Statistics";

        /// <summary>
        /// Statistics of issued and received invoices for given period of time.
        /// </summary>
        /// <param name="periodType">Type of time period.</param>
        /// <param name="filterModel">Filter model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="InvoicingForPeriodGetModel"/>.</returns>
        public ApiResult<InvoicingForPeriodGetModel> InvoicingForPeriod(PeriodType periodType, StatisticsFilterModel filterModel = null)
        {
            var queryParams = new Dictionary<string, string> { { nameof(PeriodType), periodType.ToString() } };
            var withFilterParams = queryParams.Concat(filterModel?.AsDictionary() ?? new Dictionary<string, string>())
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return Get<InvoicingForPeriodGetModel>($"{ResourceUrl}/InvoicingForPeriod", withFilterParams);
        }

        /// <summary>
        /// Statistics of issued and received invoices for given year.
        /// </summary>
        /// <param name="yearType">Type of year.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="InvoicingForYearGetModel"/>.</returns>
        public Task<ApiResult<InvoicingForYearGetModel>> InvoicingForYearAsync(YearType yearType, CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string> { { nameof(YearType), yearType.ToString() } };

            return GetAsync<InvoicingForYearGetModel>($"{ResourceUrl}/InvoicingForYear", queryParams, cancellationToken);
        }

        /// <summary>
        /// Statistics for issued and received invoices.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="List{QuarterSummaryGetModel}"/>.</returns>
        public Task<ApiResult<List<QuarterSummaryGetModel>>> QuarterSummaryAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<QuarterSummaryGetModel>>($"{ResourceUrl}/QuarterSummary", null, cancellationToken);
        }

        /// <summary>
        /// Statistics for top partners.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="List{TopPartnerGetModel}"/>.</returns>
        public Task<ApiResult<List<TopPartnerGetModel>>> TopPartnersAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<TopPartnerGetModel>>($"{ResourceUrl}/TopPartners", null, cancellationToken);
        }

        /// <summary>
        /// Count of documents.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="AgendaSummaryGetModel"/>.</returns>
        public Task<ApiResult<AgendaSummaryGetModel>> AgendaSummaryAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<AgendaSummaryGetModel>($"{ResourceUrl}/AgendaSummary", null, cancellationToken);
        }

        /// <summary>
        /// Statistics for top partners.
        /// </summary>
        /// <param name="id">Id of contact.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        public Task<ApiResult<ContactStatisticGetModel>> StatisticForContactAsync(int id, CancellationToken cancellationToken = default)
        {
            return GetAsync<ContactStatisticGetModel>($"{ResourceUrl}/StatisticForContact/{id}", null, cancellationToken);
        }
    }
}
