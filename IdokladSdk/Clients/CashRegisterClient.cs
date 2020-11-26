using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.CashRegister;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with cash register endpoints.
    /// </summary>
    public partial class CashRegisterClient : BaseClient,
        IDeleteRequest,
        IEntityDetail<CashRegisterDetail>,
        IEntityList<CashRegisterList>,
        IPatchRequest<CashRegisterPatchModel, CashRegisterGetModel>,
        IPostRequest<CashRegisterPostModel, CashRegisterGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashRegisterClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public CashRegisterClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/CashRegisters";

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
        }

        /// <inheritdoc/>
        public CashRegisterDetail Detail(int id)
        {
            return new CashRegisterDetail(id, this);
        }

        /// <inheritdoc/>
        public CashRegisterList List()
        {
            return new CashRegisterList(this);
        }

        /// <inheritdoc />
        public ApiResult<CashRegisterGetModel> Post(CashRegisterPostModel model)
        {
            return Post<CashRegisterPostModel, CashRegisterGetModel>(model);
        }

        /// <inheritdoc />
        public ApiResult<CashRegisterGetModel> Update(CashRegisterPatchModel model)
        {
            return Patch<CashRegisterPatchModel, CashRegisterGetModel>(model);
        }
    }
}
