namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// DeleteResultModel.
    /// </summary>
    public class DeleteResultModel
    {
        /// <summary>
        /// Gets or sets id of deleted document.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether delete was successful.
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
