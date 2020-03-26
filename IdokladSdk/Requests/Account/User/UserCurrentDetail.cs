using IdokladSdk.Clients;
using IdokladSdk.Models.Account;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Account.User
{
    /// <summary>
    /// UserCurrentDetail.
    /// </summary>
    public class UserCurrentDetail : BaseDetail<UserCurrentDetail, AccountClient, UserGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCurrentDetail"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public UserCurrentDetail(AccountClient client)
            : base(client)
        {
        }

        /// <inheritdoc/>
        protected override string DetailName { get; } = "CurrentUser";
    }
}
