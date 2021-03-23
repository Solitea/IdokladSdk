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
