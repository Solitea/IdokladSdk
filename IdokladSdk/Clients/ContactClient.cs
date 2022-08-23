using System;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Contact;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with contact endpoints.
    /// </summary>
    public partial class ContactClient :
        BaseClient,
        IDeleteRequest,
        IDefaultRequest<ContactPostModel>,
        IPostRequest<ContactPostModel, ContactGetModel>,
        IPatchRequest<ContactPatchModel, ContactGetModel>,
        IEntityDetail<ContactDetail>,
        IEntityList<ContactList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public ContactClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/Contacts";

        /// <inheritdoc/>
        public ContactDetail Detail(int id)
        {
            return new ContactDetail(id, this);
        }

        /// <inheritdoc/>
        public ContactList List()
        {
            return new ContactList(this);
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<ContactGetModel> Post(ContactPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<ContactGetModel> Update(ContactPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<ContactPostModel> Default()
        {
            return DefaultAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
        }
    }
}
