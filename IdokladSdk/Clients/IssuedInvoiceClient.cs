using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.IssuedInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with issued invoice endpoints.
    /// </summary>
    public class IssuedInvoiceClient :
        BaseClient,
        ICopyRequest<IssuedInvoiceCopyGetModel>,
        IDeleteRequest,
        IEntityDetail<IssuedInvoiceDetail>,
        IEntityList<IssuedInvoiceList>,
        IDefaultRequest<IssuedInvoicePostModel>,
        IDefaultWithIdRequest<IssuedInvoicePostModel>,
        IPostRequest<IssuedInvoicePostModel, IssuedInvoiceGetModel>,
        IPatchRequest<IssuedInvoicePatchModel, IssuedInvoiceGetModel>,
        IRecountRequest<IssuedInvoiceRecountPostModel, IssuedInvoiceRecountGetModel>,
        IRecurrenceRequest<RecurringInvoicePostModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public IssuedInvoiceClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/IssuedInvoices";

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<IssuedInvoiceCopyGetModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoicePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<IssuedInvoicePostModel>(cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoicePostModel>> DefaultAsync(int templateId, CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string>() { { "templateId", templateId.ToString(CultureInfo.InvariantCulture) } };
            return DefaultAsync<IssuedInvoicePostModel>(queryParams, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public IssuedInvoiceDetail Detail(int id)
        {
            return new IssuedInvoiceDetail(id, this);
        }

        /// <inheritdoc />
        public IssuedInvoiceList List()
        {
            return new IssuedInvoiceList(this);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceGetModel>> PostAsync(IssuedInvoicePostModel model, CancellationToken cancellationToken = default)
        {
            ValidatePost(model);
            return PostAsync<IssuedInvoicePostModel, IssuedInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceRecountGetModel>> RecountAsync(IssuedInvoiceRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<IssuedInvoiceRecountPostModel, IssuedInvoiceRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<RecurringInvoicePostModel>> RecurrenceAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Recurrence";
            return GetAsync<RecurringInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceGetModel>> UpdateAsync(IssuedInvoicePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<IssuedInvoicePatchModel, IssuedInvoiceGetModel>(model, cancellationToken);
        }

        private void ValidatePost(IssuedInvoicePostModel model)
        {
            _ = model ?? throw new ArgumentNullException(nameof(model));

            if (model.ProformaInvoices == null || !model.ProformaInvoices.Any())
            {
                if (model.Items.Any(i => i.ItemType != PostIssuedInvoiceItemType.ItemTypeNormal))
                {
                    throw new ValidationException("Issued invoice can contain only normal items.");
                }
            }
            else
            {
                if (model.Items.Any(i => i.ItemType != PostIssuedInvoiceItemType.ItemTypeNormal && i.ItemType != PostIssuedInvoiceItemType.ItemTypeReduce))
                {
                    throw new ValidationException("Issued invoice can contain only normal or deductive items.");
                }
            }
        }
    }
}
