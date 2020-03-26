namespace IdokladSdk.Models.NumericSequence
{
    /// <summary>
    /// DocumentNumbersItemGetModel.
    /// </summary>
    public class DocumentNumbersItemGetModel
    {
        /// <summary>
        /// Gets or sets document Number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is unique.
        /// </summary>
        public bool IsUnique { get; set; } = true;

        /// <summary >
        /// Gets or sets numeric sequence id.
        /// </summary>
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }
    }
}
