namespace IdokladSdk.Models.Base
{
    /// <summary>
    /// File.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Gets or sets filename.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets bytes of a file.
        /// </summary>
        byte[] FileBytes { get; set; }
    }
}
