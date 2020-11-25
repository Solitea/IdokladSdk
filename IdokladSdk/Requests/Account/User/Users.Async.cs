using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Account;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Account.User
{
    public partial class Users
    {
        /// <inheritdoc />
        public Task<ApiResult<UserGetModel>> UpdateAsync(UserPatchModel model, CancellationToken cancellationToken = default)
        {
            return _client.PatchAsync<UserPatchModel, UserGetModel>(CurrentUserUrl, model, cancellationToken);
        }
    }
}
