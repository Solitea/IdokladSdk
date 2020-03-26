using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for GET endpoints which returns detail of entity.
    /// </summary>
    /// <typeparam name="TModel">GET model.</typeparam>
    public interface IGetDetailRequest<TModel>
        where TModel : new()
    {
        /// <summary>
        /// Retrieves an entity.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        ApiResult<TModel> Get();

        /// <inheritdoc cref="Get"/>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<ApiResult<TModel>> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an entity mapped to custom type.
        /// </summary>
        /// <typeparam name="TCustomModel">Custom model type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        ApiResult<TCustomModel> Get<TCustomModel>()
            where TCustomModel : new();

        /// <inheritdoc cref="Get{TCustomModel}()"/>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<ApiResult<TCustomModel>> GetAsync<TCustomModel>(CancellationToken cancellationToken = default)
            where TCustomModel : new();

        /// <summary>
        /// Retrieves an entity and transforms it to custom type by calling a transform function.
        /// </summary>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <returns><see cref="ApiResult{TResult}"/> instance.</returns>
        ApiResult<TResult> Get<TResult>(Expression<Func<TModel, TResult>> selector);

        /// <summary>
        /// Retrieves an entity and transforms it to custom type by calling a transform function.
        /// </summary>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <returns><see cref="ApiResult{TResult}"/> instance.</returns>
        Task<ApiResult<TResult>> GetAsync<TResult>(Expression<Func<TModel, TResult>> selector, CancellationToken cancellationToken = default);
    }
}
