using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.SalesPosEquipment
{
    /// <summary>
    /// Detail of authorized sales pos equipment async.
    /// </summary>
    public partial class SalesPosEquipmentInfo
    {
        /// <inheritdoc/>
        protected override Task<ApiResult<TResult>> GetCoreAsync<TResult>(Dictionary<string, string> queryParams, CancellationToken cancellationToken = default)
        {
            return Client.GetAsync<TResult>($"{Client.ResourceUrl}/Info", queryParams, cancellationToken);
        }
    }
}
