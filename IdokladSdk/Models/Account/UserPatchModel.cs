using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// UserPatchModel.
    /// </summary>
    public class UserPatchModel
    {
        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [StringLength(50)]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to send newsletter.
        /// </summary>
        public bool? HasNewsletter { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        [StringLength(50)]
        public string Surname { get; set; }
    }
}
