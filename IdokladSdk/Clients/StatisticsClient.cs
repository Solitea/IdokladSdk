using System;
using System.Collections.Generic;
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
            var withFilterParams = queryParams.Concat(filterModel?.AsDictionary() ?? new Dictionary<string, string>())
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return Get<InvoicingForPeriodGetModel>($"{ResourceUrl}/InvoicingForPeriod", withFilterParams);
        }

        /// <summary>
        /// Statistics of issued and received invoices for given year.
        /// </summary>
        /// <param name="yearType">Type of year.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="InvoicingForYearGetModel"/>.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<InvoicingForYearGetModel> InvoicingForYear(YearType yearType)
        {
            return InvoicingForYearAsync(yearType).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Statistics for issued and received invoices.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="List{QuarterSummaryGetModel}"/>.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<List<QuarterSummaryGetModel>> QuarterSummary()
        {
            return QuarterSummaryAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Statistics for top partners.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="List{TopPartnerGetModel}"/>.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<List<TopPartnerGetModel>> TopPartners()
        {
            return TopPartnersAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Count of documents.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="AgendaSummaryGetModel"/>.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<AgendaSummaryGetModel> AgendaSummary()
        {
            return AgendaSummaryAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Statistics for top partners.
        /// </summary>
        /// <param name="id">Id of contact.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="ContactStatisticGetModel"/>.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<ContactStatisticGetModel> StatisticForContact(int id)
        {
            return StatisticForContactAsync(id).GetAwaiter().GetResult();
        }
    }
}
