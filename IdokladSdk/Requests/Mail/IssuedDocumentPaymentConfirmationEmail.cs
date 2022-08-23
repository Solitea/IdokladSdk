using System;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Send(int id)
        {
            return SendAsync(id).GetAwaiter().GetResult();
        }

        private string GetResourceUrl(int id) => $"{Client.ResourceUrl}/{DocumentType}/SendConfirmation/{id}";
    }
}
