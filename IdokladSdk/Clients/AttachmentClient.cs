using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Attachment;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with attachment endpoints.
    /// </summary>
    public partial class AttachmentClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public AttachmentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/Attachments/";

        /// <summary>
        /// Gets attachment.
        /// </summary>
        /// <param name="attachmentId">Id of an attachment.</param>
        /// <param name="compressed"><c>true</c> if the attachment should be compressed, otherwise <c>false</c>.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing attachment.</returns>
        public ApiResult<AttachmentGetModel> Get(int attachmentId, bool compressed = false)
        {
            var resource = ResourceUrl + $"{attachmentId}";
            var queryParams = new Dictionary<string, string>
            {
                { "compressed", compressed.ToString() }
            };

            return Get<AttachmentGetModel>(resource, queryParams);
        }

        /// <summary>
        /// Gets document's attachments.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <param name="compressed"><c>true</c> if attachments should be compressed, otherwise <c>false</c>.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing list of attachments.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<List<AttachmentGetModel>> Get(int documentId, AttachmentDocumentType documentType, bool compressed = false)
        {
            return GetAsync(documentId, documentType, compressed).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Uploads attachment to document. Maximum attachment count is five.
        /// </summary>
        /// <param name="model">File to upload.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if upload of an attachment was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> Upload(AttachmentUploadModel model)
        {
            return UploadAsync(model).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes document.
        /// </summary>
        /// <param name="attachmentId">Id of an attachment.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if deletion of an attachment was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> Delete(int attachmentId)
        {
            var resource = ResourceUrl + $"{attachmentId}";
            return Delete<bool>(resource);
        }

        /// <summary>
        /// Deletes all document's attachments.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if deletion of all attachments was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> Delete(int documentId, AttachmentDocumentType documentType)
        {
            return DeleteAsync(documentId, documentType).GetAwaiter().GetResult();
        }

        private bool IsAttachmentNameValid(AttachmentUploadModel attachment)
        {
            var unsupportedChars = new char[] { '\\', '/', '"', ':', '?', '*', '<', '>', '|', '“' };
            return attachment.FileName.IndexOfAny(unsupportedChars) == -1;
        }
    }
}
