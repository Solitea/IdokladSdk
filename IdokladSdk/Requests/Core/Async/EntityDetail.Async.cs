using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core
{
    public abstract partial class EntityDetail<TDetail, TClient, TGetModel>
    {
        /// <inheritdoc />
        protected override Task<ApiResult<TResult>> GetCoreAsync<TResult>(Dictionary<string, string> queryParams, CancellationToken cancellationToken = default)
        {
            return Client.GetAsync<TResult>($"{ResourceUrl}/{Id}", queryParams, cancellationToken);
        }
    }
}
