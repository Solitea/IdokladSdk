using System;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Models.IssuedTaxDocument.Post;
using IdokladSdk.Requests.IssuedTaxDocument;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// IssuedTaxDocumentClient.
    /// </summary>
    public partial class IssuedTaxDocumentClient :
        BaseClient,
        IDefaultWithIdRequest<IssuedTaxDocumentGetModel>,
        IEntityDetail<IssuedTaxDocumentDetail>,
        IEntityList<IssuedTaxDocumentList>,
        IDeleteRequest,
        IPatchRequest<IssuedTaxDocumentPatchModel, IssuedTaxDocumentGetModel>,
        IPostRequest<IssuedTaxDocumentPostModel, IssuedTaxDocumentGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedTaxDocumentClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public IssuedTaxDocumentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/IssuedTaxDocuments";

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedTaxDocumentGetModel> Default(int id)
        {
            return DefaultAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public IssuedTaxDocumentDetail Detail(int id)
        {
            return new IssuedTaxDocumentDetail(id, this);
        }

        /// <inheritdoc/>
        public IssuedTaxDocumentList List()
        {
            return new IssuedTaxDocumentList(this);
        }

        /// <summary>
        /// Creates new issued tax document from proforma payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>New issued tax document.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedTaxDocumentGetModel> Post(int id)
        {
            return PostAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedTaxDocumentGetModel> Post(IssuedTaxDocumentPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedTaxDocumentGetModel> Update(IssuedTaxDocumentPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
