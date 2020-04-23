using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// Reminders email.
    /// </summary>
    public partial class RemindersEmail : Email, IEmail<EmailSendResult, RemindersEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemindersEmail" /> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public RemindersEmail(MailClient client)
            : base(client)
        {
            DocumentType = "Reminders";
        }

        /// <inheritdoc />
        public ApiResult<EmailSendResult> Send(RemindersEmailSettings settings)
        {
            return Send<RemindersEmailSettings>(settings);
        }
    }
}
