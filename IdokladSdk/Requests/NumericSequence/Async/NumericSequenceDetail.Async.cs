using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.NumericSequence
{
    public partial class NumericSequenceDetail
    {
        /// <inheritdoc />
        protected override Task<ApiResult<TResult>> GetCoreAsync<TResult>(Dictionary<string, string> queryParams, CancellationToken cancellationToken = default)
        {
            return Client.GetAsync<TResult>(DetailUrl, queryParams, cancellationToken);
        }
    }
}
