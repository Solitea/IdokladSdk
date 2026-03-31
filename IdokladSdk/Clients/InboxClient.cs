using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Inbox.Get;
using IdokladSdk.Models.Inbox.Post;
using IdokladSdk.Requests.Inbox;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with inbox endpoints.
    /// </summary>
    public class InboxClient : BaseClient,
        IDeleteRequest,
        IEntityDetail<InboxDetail>,
        IEntityList<InboxList>,
        IPostRequest<InboxPostModel, List<InboxListGetModel>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InboxClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public InboxClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Inbox";

        /// <summary>
        /// Attaches document to inbox item.
        /// </summary>
        /// <param name="model">Attach document model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Updated inbox detail.</returns>
        public Task<ApiResult<InboxDetailGetModel>> AttachDocumentAsync(InboxAttachDocumentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<InboxAttachDocumentPostModel, InboxDetailGetModel>($"{ResourceUrl}/AttachDocument", model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync(id, false, cancellationToken);
        }

        /// <summary>
        /// Deletes inbox item.
        /// </summary>
        /// <param name="id">Inbox item id.</param>
        /// <param name="deleteAttachment">Delete physical attachment if set to <c>true</c>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Operation result.</returns>
        public async Task<ApiResult<bool>> DeleteAsync(int id, bool deleteAttachment, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}";
            var queryParams = new Dictionary<string, string>
            {
                { "deleteAttachment", deleteAttachment.ToString() }
            };
            var resourceUri = await CreateResourceWithQueryStringAsync(resource, queryParams).ConfigureAwait(false);

            return await DeleteAsync<bool>(resourceUri, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Detaches document from inbox item.
        /// </summary>
        /// <param name="model">Detach document model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Updated inbox detail.</returns>
        public Task<ApiResult<InboxDetailGetModel>> DetachDocumentAsync(InboxDetachDocumentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<InboxDetachDocumentPostModel, InboxDetailGetModel>($"{ResourceUrl}/DetachDocument", model, cancellationToken);
        }

        /// <inheritdoc />
        public InboxDetail Detail(int id)
        {
            return new InboxDetail(id, this);
        }

        /// <inheritdoc />
        public InboxList List()
        {
            return new InboxList(this);
        }

        /// <inheritdoc />
        public Task<ApiResult<List<InboxListGetModel>>> PostAsync(InboxPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<InboxPostModel, List<InboxListGetModel>>(model, cancellationToken);
        }

        /// <summary>
        /// Registers inbox for current agenda.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Inbox settings.</returns>
        public Task<ApiResult<InboxSettingsGetModel>> RegisterAsync(CancellationToken cancellationToken = default)
        {
            return PutAsync<InboxSettingsGetModel>($"{ResourceUrl}/Register", null, cancellationToken);
        }

        /// <summary>
        /// Sends inbox item to AI review.
        /// </summary>
        /// <param name="model">AI review model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Operation result.</returns>
        public Task<ApiResult<bool>> RequestAiReviewAsync(InboxAIReviewPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<InboxAIReviewPostModel, bool>($"{ResourceUrl}/AIReview", model, cancellationToken);
        }

        private static async Task<string> CreateResourceWithQueryStringAsync(string resource, Dictionary<string, string> queryParams)
        {
            if (queryParams is null || queryParams.Count == 0)
            {
                return resource;
            }

            var queryContent = new FormUrlEncodedContent(queryParams);
            var queryString = await queryContent.ReadAsStringAsync().ConfigureAwait(false);

            return $"{resource}?{queryString}";
        }
    }
}
