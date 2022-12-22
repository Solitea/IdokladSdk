using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.RegisteredSale;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with registered sale endpoints.
    /// </summary>
    public class RegisteredSaleClient :
        BaseClient,
        IDefaultRequest<RegisteredSalePostModel>,
        IEntityList<RegisteredSaleList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredSaleClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public RegisteredSaleClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/RegisteredSales";

        /// <inheritdoc/>
        public Task<ApiResult<RegisteredSalePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<RegisteredSalePostModel>(cancellationToken);
        }

        /// <inheritdoc cref="IEntityDetail{TDetail}.Detail"/>
        /// <param name="type">Type of document.</param>
        /// <param name="id">Id of document.</param>
        public RegisteredSaleDetail Detail(RegisteredSaleType type, int id)
        {
            return new RegisteredSaleDetail(type, id, this);
        }

        /// <inheritdoc/>
        public RegisteredSaleList List()
        {
            return new RegisteredSaleList(this);
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
