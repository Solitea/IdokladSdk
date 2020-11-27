using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Attachment;
using IdokladSdk.Response;
using RestSharp;

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
        /// Gets document attachment.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <param name="compressed"><c>true</c> if the document should be compressed, otherwise <c>false</c>.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing list of attachments.</returns>
        public ApiResult<List<AttachmentGetModel>> Get(int documentId, AttachmentDocumentType documentType, bool compressed = false)
        {
            var resource = ResourceUrl + $"{documentId}/{documentType}/{compressed}";
            return Get<List<AttachmentGetModel>>(resource);
        }

        /// <summary>
        /// Uploads attachment to document.
        /// </summary>
        /// <param name="model">File to upload.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if upload of a document was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> Upload(AttachmentUploadModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!IsAttachmentNameValid(model))
            {
                throw new ValidationException("File name contains one or more unsupported characters");
            }

            var resource = ResourceUrl + $"{model.DocumentId}/{model.DocumentType}";
            var request = CreateRequest(resource, Method.PUT);
            request.AddFile(model.FileName, model.FileBytes, model.FileName);
            request.AlwaysMultipartFormData = true;
            return Client.Execute<ApiResult<bool>>(request).Data;
        }

        /// <summary>
        /// Deletes document.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if deletion of a document was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> Delete(int documentId, AttachmentDocumentType documentType)
        {
            var resource = ResourceUrl + $"{documentId}/{documentType}";
            return Delete<bool>(resource);
        }

        private bool IsAttachmentNameValid(AttachmentUploadModel attachment)
        {
            var unsupportedChars = new char[] { '\\', '/', '"', ':', '?', '*', '<', '>', '|', '“' };
            return attachment.FileName.IndexOfAny(unsupportedChars) == -1;
        }
    }
}
