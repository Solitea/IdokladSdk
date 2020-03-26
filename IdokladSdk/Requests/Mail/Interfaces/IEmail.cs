using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail.Interfaces
{
    /// <summary>
    /// Email interface.
    /// </summary>
    /// <typeparam name="TSettings">Email settings type.</typeparam>
    public interface IEmail<in TSettings>
    {
        /// <summary>
        /// Sends email.
        /// </summary>
        /// <param name="settings">Settings.</param>
        /// <returns>Result.</returns>
        ApiResult<EmailSendResult> Send(TSettings settings);

        /// <summary>
        /// Sends email.
        /// </summary>
        /// <param name="settings">Settings.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Result.</returns>
        Task<ApiResult<EmailSendResult>> SendAsync(TSettings settings, CancellationToken cancellationToken = default);
    }
}
