using IdokladSdk.Enums;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// Request company info response model.
    /// </summary>
    public class RequestCompanyInfoResponseModel
    {
        /// <summary>
        /// Gets or sets a change result.
        /// </summary>
        public RequestCompanyInfoChangeResult ChangeResult { get; set; }

        /// <summary>
        /// Gets or sets Email address, to which the email for confirmation of changes was sent.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
