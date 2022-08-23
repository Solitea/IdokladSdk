using System;
using System.Collections.Generic;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for batch operations.
    /// </summary>
    public partial class BatchClient : BaseClient
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
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        public ApiBatchResult<UpdateExportedModel> Update(IList<UpdateExportedModel> models)
        {
            return UpdateAsync(models).GetAwaiter().GetResult();
        }
    }
}
