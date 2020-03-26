using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Enums;
using IdokladSdk.Exceptions;

namespace IdokladSdk.Response
{
    /// <summary>
    /// API batch result.
    /// </summary>
    /// <typeparam name="TData">Returned data from endpoints.</typeparam>
    public class ApiBatchResult<TData> : ApiBatchResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiBatchResult{TData}"/> class.
        /// </summary>
        public ApiBatchResult()
        {
            Results = new List<ApiResult<TData>>();
        }

        /// <summary>
        /// Gets or sets results of batch operation.
        /// </summary>
        public IList<ApiResult<TData>> Results { get; set; }

        /// <summary>
        /// Gets batch result type.
        /// </summary>
        public override BatchResultType Status
            => Results.All(x => x.IsSuccess) ? BatchResultType.Success
                : Results.All(x => !x.IsSuccess) ? BatchResultType.Failure
                : BatchResultType.PartialSuccess;

        /// <summary>
        /// Checks API response and returns data if operation was successful; otherwise throws an exception.
        /// </summary>
        /// <param name="acceptPartialSuccess">If set, partial success is accepted as success.</param>
        /// <returns>Data from API.</returns>
        public IEnumerable<TData> CheckResult(bool acceptPartialSuccess = false)
        {
            if (Status == BatchResultType.Failure || (Status == BatchResultType.PartialSuccess && !acceptPartialSuccess))
            {
                throw new IdokladSdkException(this);
            }

            return Results.Select(r => r.Data);
        }

        /// <inheritdoc/>
        public override IEnumerable<ApiResult> GetBaseResults() => Results.Cast<ApiResult>();
    }
}
