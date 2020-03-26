namespace IdokladSdk.Models.NumericSequence
{
    /// <summary>
    /// DocumentNumbersGetModel.
    /// </summary>
    public class DocumentNumbersGetModel
    {
        /// <summary>
        /// Gets or sets unique document numbers.
        /// </summary>
        public DocumentNumbersItemGetModel Unique { get; set; }

        /// <summary>
        /// Gets or sets custom document numbers.
        /// </summary>
        public DocumentNumbersItemGetModel Custom { get; set; }
    }
}
