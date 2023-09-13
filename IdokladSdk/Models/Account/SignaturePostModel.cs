using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// SignaturePostModel.
    /// </summary>
    public class SignaturePostModel : ValidatableModel, IFile
    {
        /// <summary>
        /// Gets or sets filename.
        /// </summary>
        [LogoAndSignatureExtension]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets bytes of a file.
        /// </summary>
        public byte[] FileBytes { get; set; }
    }
}
