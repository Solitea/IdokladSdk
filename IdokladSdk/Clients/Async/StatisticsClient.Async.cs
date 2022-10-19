using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.Statistics;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class StatisticsClient
    {
        /// <summary>
        /// Statistics of issued and received invoices for given period of time.
        /// </summary>
        /// <param name="periodType">Type of time period.</param>
        /// <param name="filterModel">Filter model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="InvoicingForPeriodGetModel"/>.</returns>
        public Task<ApiResult<InvoicingForPeriodGetModel>> InvoicingForPeriodAsync(PeriodType periodType, StatisticsFilterModel filterModel = null,  CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string> { { nameof(PeriodType), periodType.ToString() } };
            var withFilterParams = queryParams.Concat(filterModel?.AsDictionary()).ToDictionary(pair => pair.Key, pair => pair.Value);

            return GetAsync<InvoicingForPeriodGetModel>($"{ResourceUrl}/InvoicingForPeriod", withFilterParams, cancellationToken);
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

        /// <inheritdoc cref="QuarterSummary"/>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<ApiResult<List<QuarterSummaryGetModel>>> QuarterSummaryAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<QuarterSummaryGetModel>>($"{ResourceUrl}/QuarterSummary", null, cancellationToken);
        }

        /// <inheritdoc cref="TopPartners"/>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<ApiResult<List<TopPartnerGetModel>>> TopPartnersAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<TopPartnerGetModel>>($"{ResourceUrl}/TopPartners", null, cancellationToken);
        }

        /// <inheritdoc cref="AgendaSummary"/>
        /// <param name="cancellationToken">Cancellation token.</param>
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
