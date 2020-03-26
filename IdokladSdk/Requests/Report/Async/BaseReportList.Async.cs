using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report
{
    public abstract partial class BaseReportList<TList, TClient, TGetModel, TFilter, TSort>
        where TList : BaseReportList<TList, TClient, TGetModel, TFilter, TSort>
        where TClient : BaseClient
        where TFilter : new()
        where TSort : new()
    {
        /// <summary>
        /// Call Get endpoint.
        /// </summary>
        /// <param name="language">Language.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<TGetModel>> GetAsync(Language language, CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParameters();
            var resource = $"{_client.ResourceUrl}{_documentType}/Pdf/List/{language}";
            return _client.GetAsync<TGetModel>(resource, queryParams, cancellationToken);
        }
    }
}
