using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.Attachment;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk.Clients
{
    public partial class AttachmentClient
    {
        /// <summary>
        /// Gets attachment.
        /// </summary>
        /// <param name="attachmentId">Attachment Id.</param>
        /// <param name="compressed"><c>true</c> if the attachment should be compressed, otherwise <c>false</c>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing attachment.</returns>
        public Task<ApiResult<AttachmentGetModel>> GetAsync(int attachmentId, bool compressed = false, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + $"{attachmentId}";
            var queryParams = new Dictionary<string, string>
            {
                { "compressed", compressed.ToString() }
            };

            return GetAsync<AttachmentGetModel>(resource, queryParams, cancellationToken);
        }

        /// <summary>
        /// Gets document's attachments.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <param name="compressed"><c>true</c> if the attachment should be compressed, otherwise <c>false</c>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing list of attachments.</returns>
        public Task<ApiResult<List<AttachmentGetModel>>> GetAsync(int documentId, AttachmentDocumentType documentType, bool compressed = false, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + $"{documentId}/{documentType}/{compressed}";
            return GetAsync<List<AttachmentGetModel>>(resource, null, cancellationToken);
        }

        /// <inheritdoc cref="Upload"/>
        public async Task<ApiResult<bool>> UploadAsync(AttachmentUploadModel model, CancellationToken cancellationToken = default)
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
            var request = await CreateRequestAsync(resource, HttpMethod.Put, cancellationToken).ConfigureAwait(false);
            request.AddFile(model.FileName, model.FileBytes, model.FileName);
            request.AlwaysMultipartFormData = true;
            return (await Client.ExecuteAsync<ApiResult<bool>>(request, cancellationToken).ConfigureAwait(false)).Data;
        }

        /// <summary>
        /// Deletes attachment.
        /// </summary>
        /// <param name="attachmentId">Attachment Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if deletion of an attachment was successful, otherwise <c>false</c>.</returns>
        public Task<ApiResult<bool>> DeleteAsync(int attachmentId, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + $"{attachmentId}";
            return DeleteAsync<bool>(resource, cancellationToken);
        }

        /// <summary>
        /// Deletes all document's attachments.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if deletion of all attachments was successful, otherwise <c>false</c>.</returns>
        public Task<ApiResult<bool>> DeleteAsync(int documentId, AttachmentDocumentType documentType, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + $"{documentId}/{documentType}";
            return DeleteAsync<bool>(resource, cancellationToken);
        }
    }
}
