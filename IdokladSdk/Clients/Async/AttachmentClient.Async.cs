using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <inheritdoc cref="Get"/>
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
            var request = await CreateRequestAsync(resource, Method.PUT, cancellationToken).ConfigureAwait(false);
            request.AddFile(model.FileName, model.FileBytes, model.FileName);
            request.AlwaysMultipartFormData = true;
            return (await Client.ExecuteAsync<ApiResult<bool>>(request, cancellationToken).ConfigureAwait(false)).Data;
        }

        /// <inheritdoc cref="Delete"/>
        public Task<ApiResult<bool>> DeleteAsync(int documentId, AttachmentDocumentType documentType, CancellationToken cancellationToken = default)
        {
            var resource = ResourceUrl + $"{documentId}/{documentType}";
            return DeleteAsync<bool>(resource, cancellationToken);
        }
    }
}
