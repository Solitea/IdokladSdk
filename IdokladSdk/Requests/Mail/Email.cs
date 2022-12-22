using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;
using IdokladSdk.Requests.Mail.Interfaces;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// Base class for emails.
    /// </summary>
    public abstract class Email
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="client">Mail client.</param>
        public Email(MailClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Gets or sets mail client.
        /// </summary>
        protected MailClient Client { get; set; }

        /// <summary>
        /// Gets or sets email resource URL.
        /// </summary>
        protected string DocumentType { get; set; }

        /// <inheritdoc cref="IEmail{TResult, TSettings}.SendAsync"/>
        protected Task<ApiResult<EmailSendResult>> SendAsync<TSettings>(TSettings settings, CancellationToken cancellationToken)
            where TSettings : EmailSettings, new()
        {
            Validate(settings);

            var url = $"{Client.ResourceUrl}/{DocumentType}/Send";
            return Client.PostAsync<TSettings, EmailSendResult>(url, settings, cancellationToken);
        }

        private void Validate(EmailSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (!settings.HasRecipients())
            {
                throw new ValidationException("Email has to have at least one recipient.");
            }

            if (string.IsNullOrWhiteSpace(DocumentType))
            {
                throw new ArgumentException("Document type has to be specified.", nameof(DocumentType));
            }
        }
    }
}
