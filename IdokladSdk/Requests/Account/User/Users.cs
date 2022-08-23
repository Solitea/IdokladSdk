using System;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Account;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Account.User
{
    /// <summary>
    /// User.
    /// </summary>
    public partial class Users :
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
        [Obsolete("Use async method instead.")]
        public ApiResult<UserGetModel> Update(UserPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delets user with given id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Returns true if user deletion was successfull, false otherwise.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
        }
    }
}
