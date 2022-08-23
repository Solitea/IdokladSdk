using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoiceCopyGetModel> Copy(int id)
        {
            return CopyAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoicePostModel> Default()
        {
            return DefaultAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoiceGetModel> Post(IssuedInvoicePostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoiceRecountGetModel> Recount(IssuedInvoiceRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<RecurringInvoicePostModel> Recurrence(int id)
        {
            return RecurrenceAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoiceGetModel> Update(IssuedInvoicePatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
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
