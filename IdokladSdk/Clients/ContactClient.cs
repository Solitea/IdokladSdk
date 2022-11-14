using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Contact;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with contact endpoints.
    /// </summary>
    public class ContactClient :
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
        public Task<ApiResult<ContactGetModel>> PostAsync(ContactPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ContactPostModel, ContactGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ContactGetModel>> UpdateAsync(ContactPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<ContactPatchModel, ContactGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ContactPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ContactPostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }
    }
}
