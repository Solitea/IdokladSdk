using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.CreditNote.Post;
using IdokladSdk.Models.CreditNote.Put;
using IdokladSdk.Requests.CreditNote;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with credit note endpoints.
    /// </summary>
    public partial class CreditNoteClient :
        BaseClient,
        IDeleteRequest,
        IEntityDetail<CreditNoteDetail>,
        IEntityList<CreditNoteList>,
        IDefaultWithIdRequest<CreditNoteDefaultPostModel>,
        IPostRequest<CreditNotePostModel, CreditNoteGetModel>,
        IPatchRequest<CreditNotePatchModel, CreditNoteGetModel>,
        IRecountRequest<CreditNoteRecountPostModel, CreditNoteRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditNoteClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public CreditNoteClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/CreditNotes";

        /// <inheritdoc />
        public ApiResult<CreditNoteDefaultPostModel> Default(int id)
        {
            return Default<CreditNoteDefaultPostModel>(id);
        }

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
        }

        /// <inheritdoc />
        public CreditNoteDetail Detail(int id)
        {
            return new CreditNoteDetail(id, this);
        }

        /// <inheritdoc />
        public CreditNoteList List()
        {
            return new CreditNoteList(this);
        }

        /// <summary>
        /// Creates new credit note and offsets it with invoice. Credit note should contain only items with ItemTypeNormal.
        /// </summary>
        /// <param name="model">Credit note to be created.</param>
        /// <returns><see cref="ApiResult{CreditNoteGetModel}"/> instance.</returns>
        public ApiResult<CreditNoteGetModel> Offset(CreditNotePostModel model)
        {
            var resource = $"{ResourceUrl}/Offset";
            return Post<CreditNotePostModel, CreditNoteGetModel>(resource, model);
        }

        /// <summary>
        /// Offsets existing credit note with issued invoice.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="model">Credit note offset parameters.</param>
        /// <returns><see cref="ApiResult{CreditNoteGetModel}"/> instance.</returns>
        public ApiResult<CreditNoteGetModel> Offset(int id, CreditNoteOffsetPutModel model)
        {
            var resource = $"{ResourceUrl}/{id}/Offset";
            return Put<CreditNoteOffsetPutModel, CreditNoteGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<CreditNoteGetModel> Post(CreditNotePostModel model)
        {
            return Post<CreditNotePostModel, CreditNoteGetModel>(model);
        }

        /// <inheritdoc />
        public ApiResult<CreditNoteRecountGetModel> Recount(CreditNoteRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<CreditNoteRecountPostModel, CreditNoteRecountGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<CreditNoteGetModel> Update(CreditNotePatchModel model)
        {
            return Patch<CreditNotePatchModel, CreditNoteGetModel>(model);
        }
    }
}
