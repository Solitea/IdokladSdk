using IdokladSdk.Clients;

namespace IdokladSdk.Requests.Account.User
{
    /// <summary>
    /// User.
    /// </summary>
    public class Users
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

        /// <summary>
        /// Detail endpoint.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Method return detail of user.</returns>
        public UserDetail Detail(int id)
        {
            return new UserDetail(id, _client);
        }

        /// <summary>
        /// List enpoint.
        /// </summary>
        /// <returns>Method return list of users.</returns>
        public UserList List()
        {
            return new UserList(_client);
        }

        /// <summary>
        /// Current user endpoint.
        /// </summary>
        /// <returns>Method return current detail of user.</returns>
        public UserCurrentDetail Current()
        {
            return new UserCurrentDetail(_client);
        }
    }
}
