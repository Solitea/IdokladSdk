using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    public abstract partial class Email
    {
        /// <inheritdoc cref="IEmail{TResult, TSettings}.SendAsync"/>
        protected Task<ApiResult<EmailSendResult>> SendAsync<TSettings>(TSettings settings, CancellationToken cancellationToken)
            where TSettings : EmailSettings, new()
        {
            Validate(settings);

            var url = $"{Client.ResourceUrl}/{DocumentType}/Send";
            return Client.PostAsync<TSettings, EmailSendResult>(url, settings, cancellationToken);
        }
    }
}
