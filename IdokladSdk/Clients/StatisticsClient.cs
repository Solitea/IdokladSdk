using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Statistics;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with statistic endpoints.
    /// </summary>
    public partial class StatisticsClient : BaseClient
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
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="InvoicingForPeriodGetModel"/>.</returns>
        public ApiResult<InvoicingForPeriodGetModel> InvoicingForPeriod(PeriodType periodType, StatisticsFilterModel filterModel = null)
        {
            var queryParams = new Dictionary<string, string> { { nameof(PeriodType), periodType.ToString() } };

            return Get<StatisticsFilterModel, InvoicingForPeriodGetModel>($"{ResourceUrl}/InvoicingForPeriod", filterModel, queryParams);
        }

        /// <summary>
        /// Statistics of issued and received invoices for given year.
        /// </summary>
        /// <param name="yearType">Type of year.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="InvoicingForYearGetModel"/>.</returns>
        public ApiResult<InvoicingForYearGetModel> InvoicingForYear(YearType yearType)
        {
            var queryParams = new Dictionary<string, string> { { nameof(YearType), yearType.ToString() } };

            return Get<InvoicingForYearGetModel>($"{ResourceUrl}/InvoicingForYear", queryParams);
        }

        /// <summary>
        /// Statistics for issued and received invoices.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="List{QuarterSummaryGetModel}"/>.</returns>
        public ApiResult<List<QuarterSummaryGetModel>> QuarterSummary()
        {
            return Get<List<QuarterSummaryGetModel>>($"{ResourceUrl}/QuarterSummary");
        }

        /// <summary>
        /// Statistics for top partners.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="List{TopPartnerGetModel}"/>.</returns>
        public ApiResult<List<TopPartnerGetModel>> TopPartners()
        {
            return Get<List<TopPartnerGetModel>>($"{ResourceUrl}/TopPartners");
        }

        /// <summary>
        /// Count of documents.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="AgendaSummaryGetModel"/>.</returns>
        public ApiResult<AgendaSummaryGetModel> AgendaSummary()
        {
            return Get<AgendaSummaryGetModel>($"{ResourceUrl}/AgendaSummary");
        }

        /// <summary>
        /// Statistics for top partners.
        /// </summary>
        /// <param name="id">Id of contact.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        public ApiResult<ContactStatisticGetModel> StatisticForContact(int id)
        {
            return Get<ContactStatisticGetModel>($"{ResourceUrl}/StatisticForContact/{id}");
        }
    }
}
