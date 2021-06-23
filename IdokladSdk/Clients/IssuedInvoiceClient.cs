using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.RecurringInvoice.Get;
using IdokladSdk.Requests.IssuedInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with issued invoice endpoints.
    /// </summary>
    public partial class IssuedInvoiceClient :
        BaseClient,
        ICopyRequest<IssuedInvoiceCopyGetModel>,
        IDeleteRequest,
        IEntityDetail<IssuedInvoiceDetail>,
        IEntityList<IssuedInvoiceList>,
        IDefaultRequest<IssuedInvoicePostModel>,
        IPostRequest<IssuedInvoicePostModel, IssuedInvoiceGetModel>,
        IPatchRequest<IssuedInvoicePatchModel, IssuedInvoiceGetModel>,
        IRecountRequest<IssuedInvoiceRecountPostModel, IssuedInvoiceRecountGetModel>,
        IRecurrenceRequest<RecurringInvoiceFromInvoiceGetModel>
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
        public ApiResult<IssuedInvoiceCopyGetModel> Copy(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return Get<IssuedInvoiceCopyGetModel>(resource);
        }

        /// <inheritdoc />
        public ApiResult<IssuedInvoicePostModel> Default()
        {
            return Default<IssuedInvoicePostModel>();
        }

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        public ApiResult<IssuedInvoiceGetModel> Post(IssuedInvoicePostModel model)
        {
            ValidatePost(model);
            return Post<IssuedInvoicePostModel, IssuedInvoiceGetModel>(model);
        }

        /// <inheritdoc />
        public ApiResult<IssuedInvoiceRecountGetModel> Recount(IssuedInvoiceRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<IssuedInvoiceRecountPostModel, IssuedInvoiceRecountGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<RecurringInvoiceFromInvoiceGetModel> Recurrence(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Recurrence";
            return Get<RecurringInvoiceFromInvoiceGetModel>(resource);
        }

        /// <inheritdoc />
        public ApiResult<IssuedInvoiceGetModel> Update(IssuedInvoicePatchModel model)
        {
            return Patch<IssuedInvoicePatchModel, IssuedInvoiceGetModel>(model);
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
