using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class BatchClient
    {
        /// <summary>
        /// Updates an entity's Exported property.
        /// </summary>
        /// <param name="models">Models to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        public Task<ApiBatchResult<UpdateExportedModel>> UpdateAsync(IList<UpdateExportedModel> models, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + "/Exported";

            return PutAsync<UpdateExportedModel, UpdateExportedModel>(resource, models, cancellationToken);
        }
    }
}
