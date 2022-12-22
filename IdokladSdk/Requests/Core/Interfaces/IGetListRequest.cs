using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for GET endpoints which returns list of entities.
    /// </summary>
    /// <typeparam name="TModel">GET model.</typeparam>
    public interface IGetListRequest<TModel>
        where TModel : new()
    {
        /// <summary>
        /// Retrieves a list of entities.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<Page<TModel>>> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of entities mapped to custom type.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TCustomModel">Custom model type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<Page<TCustomModel>>> GetAsync<TCustomModel>(CancellationToken cancellationToken = default)
            where TCustomModel : new();

        /// <summary>
        /// Retrieves a list of entities and transforms each entity to custom type by calling a transform function.
        /// </summary>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<Page<TResult>>> GetAsync<TResult>(Expression<Func<TModel, TResult>> selector, CancellationToken cancellationToken = default);
    }
}
