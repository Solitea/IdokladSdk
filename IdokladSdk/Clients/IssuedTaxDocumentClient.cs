using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Requests.IssuedTaxDocument;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// IssuedTaxDocumentClient.
    /// </summary>
    public partial class IssuedTaxDocumentClient :
        BaseClient,
        IEntityDetail<IssuedTaxDocumentDetail>,
        IEntityList<IssuedTaxDocumentList>,
        IDeleteRequest,
        IPatchRequest<IssuedTaxDocumentPatchModel, IssuedTaxDocumentGetModel>
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
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        public ApiResult<IssuedTaxDocumentGetModel> Post(int id)
        {
            var resource = $"{ResourceUrl}/{id}";
            return Post<IssuedTaxDocumentGetModel>(resource);
        }

        /// <inheritdoc/>
        public ApiResult<IssuedTaxDocumentGetModel> Update(IssuedTaxDocumentPatchModel model)
        {
            return Patch<IssuedTaxDocumentPatchModel, IssuedTaxDocumentGetModel>(model);
        }
    }
}
