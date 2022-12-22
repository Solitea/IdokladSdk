using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail.Interfaces
{
    /// <summary>
    /// Email interface.
    /// </summary>
    /// <typeparam name="TResult">Email result type.</typeparam>
    /// <typeparam name="TSettings">Email settings type.</typeparam>
    public interface IEmail<TResult, in TSettings>
    {
        /// <summary>
        /// Sends email.
        /// </summary>
        /// <param name="settings">Settings.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Result.</returns>
        Task<ApiResult<TResult>> SendAsync(TSettings settings, CancellationToken cancellationToken = default);
    }
}
