namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// TopPartnerGetModel.
    /// </summary>
    public class TopPartnerGetModel
    {
        /// <summary>
        /// Gets or sets Contact name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Partner contact id.
        /// </summary>
        public int PartnerContactId { get; set; }

        /// <summary>
        /// Gets or sets Total invoice sum with VAT in home currency.
        /// </summary>
        public decimal TotalWithVatHc { get; set; }
    }
}
