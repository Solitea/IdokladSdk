using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// IssuedDocumentPayment confirmation email.
    /// </summary>
    public partial class IssuedDocumentPaymentConfirmationEmail : Email, IEmail<bool, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentPaymentConfirmationEmail"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public IssuedDocumentPaymentConfirmationEmail(MailClient client)
            : base(client)
        {
            DocumentType = "IssuedDocumentPayments";
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> SendAsync(int id, CancellationToken cancellationToken = default)
        {
            return Client.PostAsync<bool>(GetResourceUrl(id), cancellationToken);
        }

        private string GetResourceUrl(int id) => $"{Client.ResourceUrl}/{DocumentType}/SendConfirmation/{id}";
    }
}
