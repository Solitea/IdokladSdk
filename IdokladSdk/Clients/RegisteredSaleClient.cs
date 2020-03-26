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
    public partial class RegisteredSaleClient :
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
        public ApiResult<RegisteredSalePostModel> Default()
        {
            return Default<RegisteredSalePostModel>();
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

        /// <inheritdoc cref="IPostRequest{TPostModel,TGetModel}.Post"/>
        /// <param name="type">Type of document for register new sale.</param>
        /// <param name="id">Id of document for register new sale.</param>
        /// <param name="model">Model of registered sale.</param>
        public ApiResult<RegisteredSaleGetModel> Post(RegisteredSaleType type, int id, RegisteredSalePostModel model)
        {
            var resource = $"{ResourceUrl}/{type}/{id}";
            return Post<RegisteredSalePostModel, RegisteredSaleGetModel>(resource, model);
        }
    }
}
