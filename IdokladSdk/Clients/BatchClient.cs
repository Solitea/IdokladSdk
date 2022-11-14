using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for batch operations.
    /// </summary>
    public class BatchClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchClient"/> class.
        /// </summary>
        /// <param name="context">API context.</param>
        public BatchClient(ApiContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl => "/Batch";

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
