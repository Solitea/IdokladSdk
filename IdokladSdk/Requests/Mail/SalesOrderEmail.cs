using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// SalesOrder email.
    /// </summary>
    public partial class SalesOrderEmail : Email, IEmail<SalesOrderEmailSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderEmail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public SalesOrderEmail(MailClient client)
            : base(client)
        {
            DocumentType = "SalesOrder";
        }

        /// <inheritdoc/>
        public ApiResult<EmailSendResult> Send(SalesOrderEmailSettings settings)
        {
            return Send<SalesOrderEmailSettings>(settings);
        }
    }
}
