using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Clients;
using IdokladSdk.Models.Email;

namespace IdokladSdk.Requests.Mail
{
    /// <summary>
    /// Base class for emails.
    /// </summary>
    public abstract partial class Email
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
