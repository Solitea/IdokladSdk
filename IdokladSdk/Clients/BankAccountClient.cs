using System;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Requests.BankAccount;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with bank accounts endpoints.
    /// </summary>
    public partial class BankAccountClient : BaseClient,
        IDeleteRequest,
        IEntityDetail<BankAccountDetail>,
        IEntityList<BankAccountList>,
        IPatchRequest<BankAccountPatchModel, BankAccountGetModel>,
        IPostRequest<BankAccountPostModel, BankAccountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public BankAccountClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/BankAccounts";

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public BankAccountDetail Detail(int id)
        {
            return new BankAccountDetail(id, this);
        }

        /// <inheritdoc />
        public BankAccountList List()
        {
            return new BankAccountList(this);
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<BankAccountGetModel> Post(BankAccountPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public ApiResult<BankAccountGetModel> Update(BankAccountPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
