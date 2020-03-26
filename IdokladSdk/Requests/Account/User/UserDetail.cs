using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Account.User
{
    /// <summary>
    /// UserDetail.
    /// </summary>
    public class UserDetail : EntityDetail<UserDetail, AccountClient, UserGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public UserDetail(int id, AccountClient client)
            : base(id, client)
        {
        }

        /// <inheritdoc />
        protected override string DetailName { get; } = "Users";
    }
}
