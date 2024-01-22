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
        public Task<ApiResult<InvoicingForPeriodGetModel>> InvoicingForPeriodAsync(PeriodType periodType, StatisticsFilterModel filterModel = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string> { { nameof(PeriodType), periodType.ToString() } };
            var withFilterParams = queryParams.Concat(filterModel?.AsDictionary() ?? new Dictionary<string, string>())
                .ToDictionary(pair => pair.Key, pair => pair.Value);

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

        /// <summary>
        /// Statistics for unpaid invoices after maturity.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        public Task<ApiResult<DebtIntervalsGetModel>> DebtIntervals(CancellationToken cancellationToken = default)
        {
            return GetAsync<DebtIntervalsGetModel>($"{ResourceUrl}/DebtIntervals", null, cancellationToken);
        }

        /// <summary>
        /// Statistics for contacts having highest cumulated debt.
        /// </summary>
        /// <param name="count">Count of top debtors to be returned.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        public Task<ApiResult<List<TopDebtorGetModel>>> TopDebtors(int? count = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string> { { nameof(count), count?.ToString() } };

            return GetAsync<List<TopDebtorGetModel>>($"{ResourceUrl}/TopDebtors", queryParams, cancellationToken);
        }

        /// <summary>
        /// Statistics for vat payer progress and its limits.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        public Task<ApiResult<VatPayerProgressGetModel>> VatPayerProgress(CancellationToken cancellationToken = default)
        {
            return GetAsync<VatPayerProgressGetModel>($"{ResourceUrl}/VatPayerProgress", null, cancellationToken);
        }

        /// <summary>
        /// Statistics for VAT record keeping for specific period.
        /// </summary>
        /// <param name="vatPeriod">VAT period.</param>
        /// <param name="isVatOnPay">Count VAT according to SK legislation for payments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        public Task<ApiResult<DashboardVatSummaryGetModel>> VatTotals(VatPeriod vatPeriod, bool isVatOnPay, CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string>
            {
                { nameof(VatPeriod), vatPeriod.ToString() },
                { nameof(isVatOnPay), isVatOnPay.ToString() }
            };

            return GetAsync<DashboardVatSummaryGetModel>($"{ResourceUrl}/VatTotals", queryParams, cancellationToken);
        }
    }
}
