namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Contacts with highest total debt.
    /// </summary>
    public class TopDebtorGetModel
    {
        /// <summary>
        /// Gets or sets contact name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Partner contact id.
        /// </summary>
        public int PartnerContactId { get; set; }

        /// <summary>
        /// Gets or sets total invoice sum with VAT in home currency.
        /// </summary>
        public decimal TotalWithVatHc { get; set; }
    }
}
