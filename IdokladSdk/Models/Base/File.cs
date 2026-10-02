namespace IdokladSdk.Models.Base
{
    /// <summary>
    /// File.
    /// </summary>
    public class File : IFile
    {
        /// <inheritdoc/>
        public string FileName { get; set; }

        /// <inheritdoc/>
        public byte[] FileBytes { get; set; }
    }
}
