using System;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Tag;
using IdokladSdk.Requests.Tag;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// TagClient.
    /// </summary>
    public partial class TagClient : BaseClient,
        IDeleteRequest,
        IEntityList<TagList>,
        IPatchRequest<TagPatchModel, TagGetModel>,
        IPostRequest<TagPostModel, TagGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public TagClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Tags";

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public TagList List()
        {
            return new TagList(this);
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<TagGetModel> Post(TagPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<TagGetModel> Update(TagPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
