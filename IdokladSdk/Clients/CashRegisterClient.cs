using System;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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
        [Obsolete("Use async method instead.")]
        public ApiResult<CashRegisterGetModel> Post(CashRegisterPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<CashRegisterGetModel> Update(CashRegisterPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
