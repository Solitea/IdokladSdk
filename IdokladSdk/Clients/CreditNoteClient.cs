using System;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<CreditNoteDefaultPostModel> Default(int id)
        {
            return DefaultAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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
        [Obsolete("Use async method instead.")]
        public ApiResult<CreditNoteGetModel> Offset(CreditNotePostModel model)
        {
            return OffsetAsync(model).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Offsets existing credit note with issued invoice.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="model">Credit note offset parameters.</param>
        /// <returns><see cref="ApiResult{CreditNoteGetModel}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<CreditNoteGetModel> Offset(int id, CreditNoteOffsetPutModel model = null)
        {
            return OffsetAsync(id, model ?? new CreditNoteOffsetPutModel()).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<CreditNoteGetModel> Post(CreditNotePostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<CreditNoteRecountGetModel> Recount(CreditNoteRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<CreditNoteGetModel> Update(CreditNotePatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
