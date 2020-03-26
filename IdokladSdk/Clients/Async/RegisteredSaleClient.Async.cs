using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class RegisteredSaleClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<RegisteredSalePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<RegisteredSalePostModel>(cancellationToken);
        }

        /// <summary>
        /// Posts new entity.
        /// </summary>
        /// <param name="type">Type of document for register new sale.</param>
        /// <param name="id">Id of document for register new sale.</param>
        /// <param name="model">Entity to be created.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public Task<ApiResult<RegisteredSaleGetModel>> PostAsync(RegisteredSaleType type, int id, RegisteredSalePostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{type}/{id}";
            return PostAsync<RegisteredSalePostModel, RegisteredSaleGetModel>(resource, model, cancellationToken);
        }
    }
}
