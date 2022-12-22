using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Account;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Account.User
{
    /// <summary>
    /// User.
    /// </summary>
    public class Users :
        IEntityDetail<UserDetail>,
        IEntityList<UserList>,
        IPatchRequest<UserPatchModel, UserGetModel>
    {
        private readonly AccountClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Users"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public Users(AccountClient client)
        {
            _client = client;
        }

        private string CurrentUserUrl => $"{_client.ResourceUrl}/CurrentUser";

        /// <summary>
        /// Current user endpoint.
        /// </summary>
        /// <returns>Method return current detail of user.</returns>
        public UserCurrentDetail Current()
        {
            return new UserCurrentDetail(_client);
        }

        /// <inheritdoc/>
        public UserDetail Detail(int id)
        {
            return new UserDetail(id, _client);
        }

        /// <inheritdoc/>
        public UserList List()
        {
            return new UserList(_client);
        }

        /// <inheritdoc />
        public Task<ApiResult<UserGetModel>> UpdateAsync(UserPatchModel model, CancellationToken cancellationToken = default)
        {
            return _client.PatchAsync<UserPatchModel, UserGetModel>(CurrentUserUrl, model, cancellationToken);
        }

        /// <summary>
        /// Delets user with given id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Returns true if user deletion was successfull, false otherwise.</returns>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return _client.DeleteAsync<bool>($"{_client.ResourceUrl}/Users/{id}", cancellationToken);
        }
    }
}
