using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Exceptions;
using IdokladSdk.Models.Attachment;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with attachment endpoints.
    /// </summary>
    public class AttachmentClient : BaseClient
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
        /// Validates an existing XML attachment according to Peppol rules.
        /// </summary>
        /// <param name="attachmentId">Id of the attachment to validate.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Validation result and errors.</returns>
        public Task<ApiResult<PeppolAttachmentValidationModel>> ValidatePeppolAsync(int attachmentId, CancellationToken cancellationToken = default)
        {
            return GetAsync<PeppolAttachmentValidationModel>($"{ResourceUrl}ValidatePeppol/{attachmentId}", null, cancellationToken);
        }

        /// <summary>
        /// Gets the files embedded in a Peppol XML attachment as a ZIP archive. Available for Slovak legislation only.
        /// </summary>
        /// <param name="attachmentId">Id of the Peppol XML attachment.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Attachment containing the ZIP archive in <see cref="AttachmentGetModel.FileBytes"/>.</returns>
        public Task<ApiResult<AttachmentGetModel>> GetPeppolAttachmentsAsync(int attachmentId, CancellationToken cancellationToken = default)
        {
            return GetAsync<AttachmentGetModel>($"{ResourceUrl}PeppolAttachments/{attachmentId}", null, cancellationToken);
        }

        /// <summary>
        /// Gets document's attachments.
        /// </summary>
        /// <param name="documentId">Id of a document.</param>
        /// <param name="documentType">Type of a document.</param>
        /// <param name="compressed"><c>true</c> if attachment should be compressed, otherwise <c>false</c>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing list of attachments.</returns>
        public Task<ApiResult<List<AttachmentGetModel>>> GetAsync(int documentId, AttachmentDocumentType documentType, bool compressed = false, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + $"{documentId}/{documentType}/{compressed}";
            return GetAsync<List<AttachmentGetModel>>(resource, null, cancellationToken);
        }

        /// <summary>
        /// Uploads attachment to document. Maximum attachment count is five.
        /// </summary>
        /// <param name="model">File to upload.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if upload of an attachment was successful, otherwise <c>false</c>.</returns>
        public async Task<ApiResult<bool>> UploadAsync(AttachmentUploadModel model, CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!IsAttachmentNameValid(model))
            {
                throw new IdokladValidationException("File name contains one or more unsupported characters");
            }

            var resource = ResourceUrl + $"{model.DocumentId}/{model.DocumentType}";

            return await PutFileAsync<bool>(resource, model, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes document.
        /// </summary>
        /// <param name="attachmentId">Id of an attachment.</param>
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

        private bool IsAttachmentNameValid(AttachmentUploadModel attachment)
        {
            var unsupportedChars = new char[] { '\\', '/', '"', ':', '?', '*', '<', '>', '|', '“' };
            return attachment.FileName.IndexOfAny(unsupportedChars) == -1;
        }
    }
}
