using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Account.User.Filter;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.Account.User
{
    /// <summary>
    /// UserList.
    /// </summary>
    public class UserList : BaseList<UserList, AccountClient, UserGetModel, UserFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public UserList(AccountClient client)
            : base(client)
        {
        }

        /// <inheritdoc />
        protected override string ListName { get; set; } = "Users";
    }
}
