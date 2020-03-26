using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.RegisteredSale
{
    public partial class RegisteredSaleDetail
    {
        /// <inheritdoc/>
        protected override Task<ApiResult<TResult>> GetCoreAsync<TResult>(Dictionary<string, string> queryParams, CancellationToken cancellationToken = default)
        {
            return Client.GetAsync<TResult>($"{Client.ResourceUrl}/{_type}/{Id}", queryParams, cancellationToken);
        }
    }
}
