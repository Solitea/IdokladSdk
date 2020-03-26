using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// UserGetModel.
    /// </summary>
    public class UserGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string Firstname { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether verified user indication.
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets user's access rights.
        /// </summary>
        public UserRight Rights { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the user's login e-mail.
        /// </summary>
        public string Username { get; set; }
    }
}
