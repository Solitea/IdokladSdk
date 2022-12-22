using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// LogoPostModel.
    /// </summary>
    public class LogoPostModel : ValidatableModel, IFile
    {
        /// <summary>
        /// Gets or sets filename.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets bytes of a file.
        /// </summary>
        public byte[] FileBytes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use higher display quality.
        /// </summary>
        public bool HighResolution { get; set; }
    }
}
